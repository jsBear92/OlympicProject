using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Models
{
    public class Podium
    {
        public int PodiumID { get; set; }
        public int EventID { get; set; }
        public int CompetitorID { get; set; }
        public string CompetitorPosition { get; set; }
        public Medal CompetitorMedal { get; set; }

        public Event Event { get; set; }
        public Competitor Competitor { get; set; }
    }
}
