using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class ReviewFormQuestions
    {
        public int id { get; set; }
        public string name { get; set; }
        public ReviewFormSections section { get; set; }
        public questionType questionType { get; set; }
    }
}
