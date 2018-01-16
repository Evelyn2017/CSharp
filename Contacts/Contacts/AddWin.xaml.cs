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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Contacts
{
    /// <summary>
    /// AddWin.xaml 的交互逻辑
    /// </summary>
    public partial class AddWin : Window
    {
        AddOne aAdd;
        public AddWin()
        {
            InitializeComponent();
            aAdd = new AddOne();
            this.DataContext = aAdd;
        }

        private void add_execute(object sender, ExecutedRoutedEventArgs e)
        {
            aAdd.Insert();
        }

        private void add_can(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
