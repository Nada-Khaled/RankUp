using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class ReviewFormOptions
    {
        public int id { get; set; }
        public string name { get; set; }
        public ReviewFormQuestions question { get; set; }
    }
}
