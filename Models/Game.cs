using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Models
{
    public class Game
    {
        
        public int GameID { get; set; }

        [Display(Name = "Game Code")]
        [StringLength(7, MinimumLength = 7)]
        [RegularExpression("[A-Za-z]{4}[0-9]{3}")]
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
        public string GameRulesBooklet { get; set; }

        public ICollection<GameCompetitor> GameCompetitors { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
