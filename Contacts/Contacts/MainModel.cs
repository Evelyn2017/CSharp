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
        //const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Conts;Integrated Security=true;";
        public MainModel()
        {
            //contsDataContext aDataContext = new contsDataContext(ConnectionString);
            //Conts aConts = (from r in aDataContext.Conts where r.id == LoginModel.id select r).FirstOrDefault();
            
            memberData.Add(new MainModel()
            {
                Name = "Joe",
                Mobile = "1522121324",
                Sex = "Male",
                Memo = "wdjiwdw",
                Birth = "1991-01-01"
            });
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
