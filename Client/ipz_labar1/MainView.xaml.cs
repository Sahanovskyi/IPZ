using System;
using System.ComponentModel;
using System.Resources;
using System.Windows;


namespace ipz_labar1
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {

            InitializeComponent();
            MainViewModel mvm = this.DataContext as MainViewModel;

            if (mvm.CloseAction == null)
                mvm.CloseAction = new Action(this.Close);
        }

        protected override void OnClosing(CancelEventArgs e)
        {

            if (!Settings1.Default.Remember)
                Settings1.Default.IsLogin = false;
            Settings1.Default.Save();
            base.OnClosing(e);
        }

    }
}
