using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Contacts
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MainModel aMain = new MainModel();
        public MainWindow()
        {
            InitializeComponent();
            
            dataGrid.DataContext = aMain.memberData;
            aMain.MainMode();

        }

        private void addOne_execute(object sender, ExecutedRoutedEventArgs e)
        {
            aMain.Add();
        }

        private void addOne_can(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Remove_can(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Remove_execute(object sender, ExecutedRoutedEventArgs e)
        {
            aMain.Remove();
        }
    }
}