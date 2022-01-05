using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class StatisticalData
    {
        public int id { get; set; }
        public string discription { get; set; }
        public int value { get; set; }
        public int oldValue { get; set; }
        public DateTime updateDate { get; set; }
    }
}
