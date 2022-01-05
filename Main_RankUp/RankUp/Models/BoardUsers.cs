using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class BoardUsers
    {
        [Required]
        public int id { get; set; }
        [Required]
        public User user { get; set; }
        [Required]
        public int CVsReviewed { get; set; }
        [Required]
        public bool isAdmin { get; set; }
        [Required]
        public bool isAvailable { get; set; } 
    }
}
