using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class BaseDataTable
    {
        public int id { get; set; }
        public string CompanyName { get; set; }
        public int maxCVReviewPerPerson { get; set; }
        public int maxCVReviewPerMonth { get; set; }
    }
}
