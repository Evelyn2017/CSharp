using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    class LoginModel : INotifyPropertyChanged
    {
        public string User {  get { return _user; } set { if (_user == value) return; _user = value; OnPropertyChanged(nameof(User)); } } 
        public string PassWord { get { return _password; } set { if (_password == value) return; _password = value; OnPropertyChanged(nameof(PassWord)); } }

        private string  _user;
        private string _password;

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }

        public void TurntoMain()
        {
            MainWindow mainWindow = new MainWindow();
            App.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
