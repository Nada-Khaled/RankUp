using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class ReviewRequests
    {
        public int id { get; set; }
        public string requestType { get; set; }
        [Required]
        public virtual User user { get; set; }
        [Required]
        public string status { get; set; }
        public BoardUsers reviewer { get; set; }
        public BoardUsers approvedBy { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime approvedDate { get; set; }
    }


}
