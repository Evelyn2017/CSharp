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
    /// SearchWin.xaml 的交互逻辑
    /// </summary>
    public partial class SearchWin : Window
    {
        public SearchWin()
        {
            InitializeComponent();
        }

        private void Search_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void Search_can(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void History_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void History_can(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
