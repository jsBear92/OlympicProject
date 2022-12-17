using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Models.ViewModels
{
    public class CollectingReport
    {
        public IEnumerable<Competitor> Competitors { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Podium> Podia { get; set; }
    }
}
