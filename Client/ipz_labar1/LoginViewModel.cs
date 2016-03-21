using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

namespace ipz_labar1
{
    public class LoginViewModel : ViewModelBase
    {
        public string username { get; set; }
        public string password { get; set; }

      
        private ICommand _login;
        public ICommand Login
        {
            get
            {
                return _login ?? (_login = new RelayCommand(() =>
                {
                    if (username.Contains(":") || password.Contains(":"))
                    {
                        MessageBox.Show("Incorect username or password. \nlogin or password shouldn't contain the \':\'");
                    }
                    else
                    {
                        if (Settings1.Default.Remember)
                        {
                            Settings1.Default.username = username;
                            Settings1.Default.password = password;
                        }
                        string data = Helper.Client.Connect(String.Format("login::{0}::{1}", username, password));
                        if (data.StartsWith("208\n"))
                        {
                            Settings1.Default.Remember = false;
                            Settings1.Default.Save();
                            MessageBox.Show("Incorect username or password");
                        }
                        else if (data.StartsWith("-1\n"))
                        {
                            Settings1.Default.Remember = false;
                            Settings1.Default.Save();
                            MessageBox.Show("Login error. Please, try again");
                        }
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

                                try { CloseAction();}
                                catch (Exception e) {}
                            }
                            else{ MessageBox.Show("Server error");}
                        }
                        else
                        {
                            Settings1.Default.Remember = false;
                            Settings1.Default.Save();
                            MessageBox.Show("Server not found");
                            if (Settings1.Default.IsLogin)
                            {
                                Settings1.Default.IsLogin = false;
                                LoginView lv = new LoginView();
                                lv.Show();

                            }
                        }
                    }

                }));
            }
        }
        private ICommand _create;
        public ICommand Create
        {
            get
            {
                return _create ?? (_create = new RelayCommand(() =>
                {
                    RegisterView rv = new RegisterView();
                    rv.Show();
                    CloseAction();
                }));
            }
        }

        public string ip { get; set; }
        public string port { get; set; }
        private ICommand _setting;
        public ICommand Setting
        {
            get
            {
                return _setting ?? (_setting = new RelayCommand(() =>
                {
                    ip = Settings1.Default.IPAddress;
                    port = Settings1.Default.Port.ToString();
                    SettingView rv = new SettingView(this);
                    rv.ShowDialog();
                }));
            }
        }
        
        private ICommand _ok;
        public ICommand Ok
        {
            get
            {
                return _ok ?? (_ok = new RelayCommand(() =>
                {
                    try
                    {
                        int potr_int = Int32.Parse(port);
                        if (potr_int < 0 || potr_int > 65535)
                            throw new Exception();
                        IPAddress address = IPAddress.Parse(ip);
                        Settings1.Default.Port = potr_int;
                        Settings1.Default.IPAddress = ip;
                        Settings1.Default.Save();
                        CloseActionSetting();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Invalid value");
                    }
                    
                }));
            }
        }

        private ICommand _cancel;
        public ICommand Cancel
        {
            get
            {
                return _cancel ?? (_cancel = new RelayCommand(() =>
                {
                    CloseActionSetting();
                }));
            }
        }

        public Action CloseAction { get; set; }
        public Action CloseActionSetting { get; set; }
    }
}
