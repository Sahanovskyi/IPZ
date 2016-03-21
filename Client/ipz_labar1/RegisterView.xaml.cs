using System;
using System.ComponentModel;
using System.Windows;

namespace ipz_labar1
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
            RegisterViewModel vm = new RegisterViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }

     
    }

    
}
