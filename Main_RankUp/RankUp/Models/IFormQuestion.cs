using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public interface IFormQuestion
    {
        public List<ReviewFormQuestions> GetOrderedQuestions();
        public ReviewFormQuestions GetQuestionById(int questionId);

    }
}
