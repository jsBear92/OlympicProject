using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Models
{
    public class GameCompetitor
    {
        public int GameID { get; set; }
        public int CompetitorID { get; set; }

        public Game Game { get; set; }
        public Competitor Competitor { get; set; }
    }
}
