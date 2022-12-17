using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Models.ViewModels
{
    public class CompetitorView
    {
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
        [MaxLength(100)]
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

        [Required(ErrorMessage = "Please choose Competitor Image")]
        [Display(Name = "Photo")]
        public IFormFile CompetitorPhoto { get; set; }
    }
}
