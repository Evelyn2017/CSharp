using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Contacts
{
    class MainModel : INotifyPropertyChanged
    {
        public ObservableCollection<MainModel> memberData = new ObservableCollection<MainModel>();
        const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Conts;Integrated Security=true;";
        //显示数据
        public void MainMode()
        {
             contsDataContext aDataContext = new contsDataContext(ConnectionString);
            var aConts = from r in aDataContext.Conts where r.id == LoginModel.id select r;

            foreach (Conts aCont in aConts)
            {
                memberData.Add(new MainModel()
                {
                    Name = aCont.name,
                    Mobile = aCont.mobile,
                    Memo = aCont.memo,
                    Sex = aCont.sex,
                    Birth = aCont.birth
                    
                });
            }   
        }

        //搜索界面
        public void TurnSearch()
        {
            SearchWin aSearch = new SearchWin();
            App.Current.MainWindow = aSearch;
            aSearch.Show();
        }

        //刷新界面
        public void Refresh()
        {
            
            MainWindow mainWindow = new MainWindow();
            App.Current.MainWindow = mainWindow;
            mainWindow.Show();
            
        }

        //增加一个联系人
        public void Add()
        {
            AddWin aAddWin = new AddWin();
            App.Current.MainWindow = aAddWin;
            aAddWin.Show();
        }

        //删除一个联系人
        public void Remove()
        {
            RemoveWin aRemo = new RemoveWin();
            App.Current.MainWindow = aRemo;
            aRemo.Show();
        }
        private string _name;
        private string _mobile;
        private string _memo;
        private string _sex;
        private string _birth;

    public string Name { get { return _name; } set { if (_name == value) return; _name = value; OnPropertyChanged(nameof(Name)); } }
    public string Mobile { get { return _mobile; } set { if (_mobile == value) return; _mobile = value; OnPropertyChanged(nameof(Mobile)); } }
    public string Memo { get { return _memo; } set { if (_memo == value) return; _memo = value; OnPropertyChanged(nameof(Memo)); } }
    public string Sex { get { return _sex; } set { if (_sex == value) return; _sex = value; OnPropertyChanged(nameof(Sex)); } }
    public string Birth { get { return _birth; } set { if (_birth == value) return; _birth = value; OnPropertyChanged(nameof(Birth)); } }

    public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
    }
}
