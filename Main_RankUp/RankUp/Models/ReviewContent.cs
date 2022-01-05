using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class ReviewContent
    {
        public int id { get; set; }
        public int requestReviewId { get; set; }
        public string sectionName { get; set; }
        public string cvReview { get; set; }


    }
}
