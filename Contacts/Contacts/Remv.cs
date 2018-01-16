using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts 
{
    class Remv : INotifyPropertyChanged
    {
        const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Conts;Integrated Security=true;";
        private string _nam;
        public string Nam { get { return _nam; } set { if (_nam == value) return; _nam = value; OnPropertyChanged(nameof(Nam)); } }

        public void remove()
        {
            contsDataContext aDataContext = new contsDataContext(ConnectionString);
            Conts aExistContact = (from r in aDataContext.Conts where r.name == Nam select r).FirstOrDefault();
            if (aExistContact != null)
            {
                aDataContext.Conts.DeleteOnSubmit(aExistContact);
            }
            aDataContext.SubmitChanges();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
}
}
