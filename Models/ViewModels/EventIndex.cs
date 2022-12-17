using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Models.ViewModels
{
    public class EventIndex
    {
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Podium> Podia { get; set; } = new List<Podium>();
        public List<EventPic> EventPics { get; set; } = new List<EventPic>();
    }
}
