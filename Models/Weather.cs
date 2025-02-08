using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Weather
    {
        public CurrentConditions CurrentConditions { get; set; }
        public Day[] Days { get; set; }
        public string Name { get; set; }
        public string ResolvedAddress { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal TimeZoneOffset { get; set; }
        public string TimeZone { get; set; }
        //public Station[] Stations { get; set; }
        public string[] Alerts { get; set; }
        public int QueryCost { get; set; }
    }
}
