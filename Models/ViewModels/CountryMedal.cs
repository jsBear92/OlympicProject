using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Models.ViewModels
{
    public class CountryMedal
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public int GoldCount { get; set; }
        public int SilverCount { get; set; }
        public int BronzeCount { get; set; }
        public int TotalCount { get; set; }
    }
}
