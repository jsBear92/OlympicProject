using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Models.ViewModels
{
    public class EventPicView
    {
        public IFormFile EventPhoto { get; set; }
        public string EventPhotoTags { get; set; }
        public int EventID { get; set; }

        public Event Event { get; set; }
    }
}
