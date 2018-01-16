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
    /// RemoveWin.xaml 的交互逻辑
    /// </summary>
    public partial class RemoveWin : Window
    {
        private Remv aRe;
        public RemoveWin()
        {
            InitializeComponent();
            aRe = new Remv();
            this.DataContext = aRe;
        }

        private void remove_execute(object sender, ExecutedRoutedEventArgs e)
        {
            aRe.remove();
        }

        private void remove_can(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
