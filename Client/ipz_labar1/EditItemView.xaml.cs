using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ipz_labar1
{
    /// <summary>
    /// Interaction logic for EditItemView.xaml
    /// </summary>
    public partial class EditItemView : Window
    {

        public EditItemView(MainViewModel o)
        {
            InitializeComponent();
            this.DataContext = o;          
            o.CloseActionEdit = new Action(this.Close);
        }
    }
}
