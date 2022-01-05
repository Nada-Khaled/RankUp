using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.ViewModels
{
    public class HRMember
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public char gender { get; set; }
        [Required]
        public bool isAdmin { get; set; }
        public bool isAvailable { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
