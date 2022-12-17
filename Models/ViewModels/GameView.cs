using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Models.ViewModels
{
    public class GameView
    {
        [Display(Name = "Game Code")]
        [RegularExpression(@"^(?=.*[A-Z].*[A-Z].*[A-Z].*[A-Z])(?=.*\d.*\d.*\d).{7}$"), StringLength(7)]
        public string GameCode { get; set; }

        [Required]
        [Display(Name = "Game Name")]
        public string GameName { get; set; }

        [Display(Name = "Duration In Hours")]
        public string GameDurationInHours { get; set; }

        [Display(Name = "Description")]
        public string GameDescription { get; set; }

        [Required]
        [Display(Name = "Game Booklet")]
        public IFormFile GameRulesBooklet { get; set; }

        public ICollection<GameCompetitor> GameCompetitors { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
