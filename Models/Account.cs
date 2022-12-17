using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicProject.Models
{
    public class Account
    {
        [Key]
        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserType { get; set; }
    }
}
