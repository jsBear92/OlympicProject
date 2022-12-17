using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Models
{

    public class Competitor
    {
        public int CompetitorID { get; set; }

        [Display(Name = "Salutation")]
        public string CompetitorSalutation { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string CompetitorName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CompetitorDoB { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Type your Email")]
        public string CompetitorEmail { get; set; }

        [Display(Name = "Description")]
        public string CompetitorDescription { get; set; }

        [Required]
        [Display(Name = "Country")]
        public CountryList CompetitorCountry { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public GenderList CompetitorGender { get; set; }

        [Display(Name = "Contact Number")]
        public string CompetitorContactNo { get; set; }

        [Display(Name = "Website")]
        public string CompetitorWebsite { get; set; }

        [Display(Name = "Photo")]
        public string CompetitorPhoto { get; set; }

        public ICollection<GameCompetitor> GameCompetitors { get; set; }
        public ICollection<Podium> Podia { get; set; }
    }

    
}
