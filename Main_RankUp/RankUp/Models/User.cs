using Microsoft.AspNetCore.Identity;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class User : IdentityUser
    {

        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public string CV { get; set; }
        [Required]
        public char gender { get; set; }
        public string photo { get; set; }
        public string jobStatus { get; set; }
        public string jobTitle { get; set; }
        public string company { get; set; }
        public DateTime jobStartDate { get; set; }
        public DateTime birthDate { get; set; }
        [Display(Name = "Industry")]
        public string industry { get; set; }
        public string univeristy { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string area { get; set; }
    }
}
