using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Hours
    {
        public string DateTime { get; set; }
        public int DateTimeEpoch { get; set; }
        public string Temp { get; set; }
        public string Feelslike { get; set; }
        public string Humidity { get; set; }
        public string Dew { get; set; }
        public string Precipitation { get; set; }
        public string Precipprob { get; set; }
        public string PrecipitationCover { get; set; }
        public string PrecipitationType { get; set; }
        public string Snow { get; set; }
        public string SnowDepth { get; set; }
        public string WindGust { get; set; }
        public string Windspeed { get; set; }
        public string WinDirection { get; set; }
        public string Pressure { get; set; }
        public string CloudCover { get; set; }
        public string Visibility { get; set; }
        public string SolarRadiation { get; set; }
        public string Solarenergy { get; set; }
        public string UVindex { get; set; }
        public string SevereRisk { get; set; }
        public string MoonPhase { get; set; }
        public string Conditions { get; set; }
        public string Description { get; set; }
        private string icon { get; set; }
        public string Icon
        {
            get => icon; set => icon = value.Replace("-", "_");
        }
        public string[] Stations { get; set; }
        public string Source { get; set; }
    }
}
