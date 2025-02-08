using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Station
    {
        public int Contribution { get; set; }
        public int Distance { get; set; }
        public string Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
        public int Quality { get; set; }
        public int UseCount { get; set; }
    }
}
