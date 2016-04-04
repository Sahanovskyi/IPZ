using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ipz_labar1
{
    class RegisterViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }

        public bool exist { get; set; }
        public string warehousename { get; set; }
        private string _passUser;
        private string _passWare;

        public string PassUser
        {
            get { return _passUser; }
            set { _passUser = value; }
        }

        public string PassWare
        {
            get { return _passWare; }
            set { _passWare = value; }
        }

        private ICommand _register;

        public ICommand Register
        {
            get
            {
                return _register ?? (_register = new RelayCommand(() =>
                {
                    if (username == null || firstName == null || lastName == null ||
                        PassUser == null || PassWare == null || warehousename == null ||
                        username.Contains(":") || firstName.Contains(":") || lastName.Contains(":") ||
                        PassUser.Contains(":") || PassWare.Contains(":") || warehousename.Contains(":"))
                    {
                        MessageBox.Show("Incorect data. \nData can not contain the \':\' or be empty");
                    }
                    else
                    {
                        string data =
                            Helper.Client.Connect(String.Format("register::{0}::{1}::{2}::{3}::{4}::{5}::{6}", firstName,
                                lastName, username, PassUser.GetHashCode(), exist.ToString(), warehousename, PassWare.GetHashCode()));
                        if (data.StartsWith("262711\n"))
                            MessageBox.Show("This user already exist");
                        else if (data.StartsWith("-2\n"))
                            MessageBox.Show("User add error");

                        else if (data.StartsWith("262722\n"))
                            MessageBox.Show("This warehouse already exist");
                        else if (data.StartsWith("-3\n") || data.StartsWith("-4\n"))
                            MessageBox.Show("Warehouse create error");
                        else if (data.StartsWith("2714\n"))
                            MessageBox.Show("Warehouse already exist");

                        else if (data.StartsWith("-1\n"))
                            MessageBox.Show("Select error");
                        else if (data.StartsWith("208\n"))
                            MessageBox.Show("Incorrec warehouse name or warehouse password");
                        else if (data.StartsWith("0\n"))
                        {
                            string[] splt = data.Split('\n');
                            MainViewModel.warehouseName = splt[1];
                            string showTable = Helper.Client.Connect(String.Format("show::{0}", splt[1]));

                            if (showTable.StartsWith("-10\n"))
                            {
                                MessageBox.Show("Werhouse show error");
                            }
                            else if (showTable.StartsWith("0\n"))
                            {
                                MainViewModel.data = showTable;
                                Settings1.Default.IsLogin = true;
                                Settings1.Default.Save();
                                MainView mv = new MainView();
                                mv.Show();
                                CloseAction();
                            }
                            else
                            {
                                MessageBox.Show("Server error");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Server error");
                        }
                    }
                }));
            }
        }

        public Action CloseAction { get; set; }
    }
}
