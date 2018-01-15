using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    class MainModel
    {
        ObservableCollection<MainModel> memberData = new ObservableCollection<MainModel>();
        memberData.Add(new MainModel()
        {
            name = "Joe", number = "23", Sex = SexOpt.Male,
                Pass = true, Email = new Uri("mailto:Joe@school.com")
        });

    }
}
