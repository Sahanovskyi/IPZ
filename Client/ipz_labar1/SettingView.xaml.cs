using System;
using System.Windows;

namespace ipz_labar1
{
    /// <summary>
    /// Interaction logic for SettingView.xaml
    /// </summary>
    public partial class SettingView : Window
    {
        public SettingView(LoginViewModel o)
        {
            InitializeComponent();
            this.DataContext = o;
            o.CloseActionSetting = new Action(this.Close);
        }
    }
}
