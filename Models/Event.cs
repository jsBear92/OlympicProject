using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Models
{
    public class Event
    {
        public int EventID { get; set; }

        public int GameID { get; set; }

        [Display(Name = "Feature Event")]
        public string FeatureEvent { get; set; }

        [Required]
        [Display(Name = "Event Venue")]
        public string EventVenu { get; set; }

        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public DateTime EventStartTime { get; set; }

        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        public DateTime EventEndTime { get; set; }

        [Required]
        [Display(Name = "Description")]
        [MaxLength(100)]
        public string EventDescription { get; set; }

        [Display(Name = "WorldRecord")]
        public string WorldRecord { get; set; }

        public Game Game { get; set; }
        public ICollection<Podium> Podia { get; set; }
        public ICollection<EventPic> EventPics { get; set; } 
    }
}
