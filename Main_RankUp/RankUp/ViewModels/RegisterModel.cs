using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.ViewModels
{
    public class RegisterModel
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public char gender { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        public string univeristy { get; set; }
        [Display(Name = "Industry")]
        public string industry { get; set; }
        public IFormFile CV { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string area { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime startDate { get; set; }
        public string jobStatus { get; set; }
        public string company { get; set; }
        public string jobTitle { get; set; }
            
    }
}
