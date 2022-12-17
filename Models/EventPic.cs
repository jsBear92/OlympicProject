using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Models
{
    public class EventPic
    {
        [Key]
        public int PhotoID { get; set; }
        public string EventPhoto { get; set; }
        public string EventPhotoTags { get; set; }
        public int EventID { get; set; }

        public Event Event { get; set; }
    }
}
