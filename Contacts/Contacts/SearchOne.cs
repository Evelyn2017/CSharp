using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Contacts
{
    class SearchOne : INotifyPropertyChanged
    {
        const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Conts;Integrated Security=true;";
        contsDataContext DataContext = new contsDataContext(ConnectionString);
        private string _str;
        public string Str { get { return _str; } set { if (_str == value) return; _str = value; OnPropertyChanged(nameof(Str)); } }
        public List<Conts> FilteredResults { get { return _FilteredResults; } set { if (_FilteredResults == value) return; _FilteredResults = value; OnPropertyChanged(nameof(FilteredResults)); } }
        private List<Conts> _FilteredResults;

        public List<string> HistoryList { get { return _HistoryList; } set { if (_HistoryList == value) return; _HistoryList = value; OnPropertyChanged(nameof(HistoryList)); } }
        private List<string> _HistoryList;


        public string Pattern { get { return _Pattern; } set { if (_Pattern == value) return; _Pattern = value; OnPropertyChanged(nameof(Pattern)); } }
        private string _Pattern;
        public Table<Conts> Schedules
        {
            get { return DataContext.Conts; }
        }


        public List<Conts> Records = new List<Conts>();

        public void SearchStr()
        {
            Records = DataContext.Conts.ToList();

            if (string.IsNullOrEmpty(Pattern))
            {
                FilteredResults = Records;
            }
            else
            {
                Regex aRegex = new Regex(Pattern);
                List<Conts> Results = new List<Conts>();
                for (int i = 0; i < Records.Count; i++)
                {
                    string Words =  Records[i].name + " " + Records[i].mobile + " " + Records[i].memo + " " + Records[i].sex + " "
                        + Records[i].birth;
                    MatchCollection aMatches = aRegex.Matches(Words);
                    for (int j = 0; j < aMatches.Count; j++)
                    {
                        if (aMatches[j].Success)
                            Results.Add(Records[i]);
                    }
                }
                FilteredResults = Results;

            }
            for (int i = 0; i < FilteredResults.Count; i++)
            {
                for (int j = FilteredResults.Count - 1; j > i; j--)
                {

                    if (FilteredResults[i] == FilteredResults[j])
                    {
                        FilteredResults.RemoveAt(j);
                    }
                }
            }

        }

        public void readXml()
        {
            List<string> aList = new List<string>();
            XDocument aXml = XDocument.Load("History.xml");
            XElement aRoot = aXml.Root;
            XElement OneHistory = aRoot.Element("OneHistory");
            XElement shuxing = OneHistory.Element("Regular");
            IEnumerable<XElement> aEnumerable = aRoot.Elements();
            foreach (XElement Item in aEnumerable)
            {
                foreach (XElement Item1 in Item.Elements())
                    if (Item1.Name.Equals(shuxing.Name))
                    {
                        aList.Add(Item1.Value);
                    }
            }
            HistoryList = aList;
        }

        public void writeXml()
        {
            XmlDocument aXml = new XmlDocument();
            XmlElement History;
            if (File.Exists("History.xml"))
            {
                aXml.Load("History.xml");
                History = aXml.DocumentElement;
            }
            else
            {
                XmlDeclaration dec = aXml.CreateXmlDeclaration("1.0", "utf-8", null);
                aXml.AppendChild(dec);
                History = aXml.CreateElement("History");
                aXml.AppendChild(History);
            }
            XmlElement OneHistory = aXml.CreateElement("OneHistory");
            History.AppendChild(OneHistory);
            XmlElement Regular = aXml.CreateElement("Regular");
            Regular.InnerText = Pattern;
            OneHistory.AppendChild(Regular);
            XmlElement Time = aXml.CreateElement("Time");
            string NowTime = System.DateTime.Now.ToString();
            Time.InnerText = NowTime;
            OneHistory.AppendChild(Time);
            aXml.Save("History.xml");
        }

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
