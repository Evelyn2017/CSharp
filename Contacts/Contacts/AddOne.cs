using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    class AddOne : INotifyPropertyChanged
    {
        const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Conts;Integrated Security=true;";

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

        public void Insert()
        {
            LoginModel aLogin = new LoginModel();
            contsDataContext aDataContext = new contsDataContext(ConnectionString);
            Conts aNewConts = new Conts
            {
                id = "131",
                name = Name,
                mobile = Mobile,
                birth = Birth,
                sex = Sex,
                memo = Memo
            };
            aDataContext.Conts.InsertOnSubmit(aNewConts);
            aDataContext.SubmitChanges();
        }

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
