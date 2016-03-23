using System;
using System.Windows;
using System.Windows.Input;

namespace ipz_labar1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            LoginViewModel lvm = this.DataContext as LoginViewModel;

            if (Settings1.Default.IsLogin)
            {
                lvm.hashPass = Settings1.Default.password;
                lvm.username = Settings1.Default.username;
                ICommand command = lvm.Login;
                command.Execute(lvm.Login);
                this.Close();
            }
            else
            {
                if (lvm.CloseAction == null)
                    lvm.CloseAction = new Action(this.Close);
                

            }


        }
    }
}
