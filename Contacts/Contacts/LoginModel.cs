using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Contacts
{
    class LoginModel : INotifyPropertyChanged
    {
        const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Conts;Integrated Security=true;";
        public string User {  get { return _user; } set { if (_user == value) return; _user = value; OnPropertyChanged(nameof(User)); } } 
        public string PassWord { get { return _password; } set { if (_password == value) return; _password = value; OnPropertyChanged(nameof(PassWord)); } }

        private string _user;
        private string _password;
        public static string id;

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }

        public void TurntoMain()
        {
            contsDataContext aDataContext = new contsDataContext(ConnectionString);
       
            User aUser = (from r in aDataContext.User where r.id == _user select r).FirstOrDefault();
            if (aUser == null) { MessageBox.Show("查无此用户"); }
            else if (aUser.password == _password)
            {
                id = aUser.id;
                MainWindow mainWindow = new MainWindow();
                App.Current.MainWindow = mainWindow;
                mainWindow.Show();
            }
            else if (aUser.password != _password) { MessageBox.Show("密码错误！"); }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
