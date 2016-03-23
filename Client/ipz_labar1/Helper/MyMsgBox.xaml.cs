using System;
using System.Threading;
using System.Windows.Forms;

using System.Threading.Tasks;
using System.Windows;

namespace ipz_labar1.Helper
{
    /// <summary>
    /// Interaction logic for MyMsgBox.xaml
    /// </summary>
    public partial class MyMsgBox : Window
    {
        public  MyMsgBox()
        {
            InitializeComponent();
           
        }
        
        public void MyShowDialog(string s)
        {
            label1.Content = s;
            ShowDialog();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void CloseMsg()
        {
            Action action = new Action(() =>
            {
                Close();
            });
            if (!Dispatcher.CheckAccess())
                Dispatcher.Invoke(action);
            else
                action();
            
        }
        public void SetLabel(string text)
        {
            Action action = new Action(() =>
            {
                label1.Content = text;
            });
            if (!Dispatcher.CheckAccess())
                Dispatcher.Invoke(action);
            else
                action();
            
        }
        
    }
}
