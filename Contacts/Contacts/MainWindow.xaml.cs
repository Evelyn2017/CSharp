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
        public MainWindow()
        {
            InitializeComponent();
            MainModel aMain = new MainModel();
            dataGrid.DataContext = aMain.memberData;
            //    ObservableCollection<MainWindow> memberData = new ObservableCollection<MainWindow>();
            //    memberData.Add(new MainWindow()
            //    {
            //        Name1 = "Joe",
            //        Mobile = "1522121324",
            //        Sex = "Male",
            //        Memo = "wdjiwdw",
            //        Birth = "1991-01-01"
            //    });
            //    dataGrid.DataContext = memberData;
        }
        //public string Name1 { get; set; }
        //public string Mobile { get; set; }
        //public string Memo { get; set; }
        //public string Birth { get; set; }
        //public string Sex { get; set; }
       

    }
}
