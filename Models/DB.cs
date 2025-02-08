using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class DB
    {
        public string DataField { get; set; }
        public DateTime Last { get; set; }
        public string Location { get; set; }
        public List<string> WLocations = new List<string>();
        public string CustumBG { get; set; }
        public List<string> Locations = new List<string>();
        public DB(string s = "Bamenda")
        {
            DataField = "";
            Location = s;
            CustumBG = "";
            Last = DateTime.Now;
        }
    }
}
