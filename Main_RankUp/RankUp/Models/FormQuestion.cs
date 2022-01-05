using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class FormQuestion : IFormQuestion
    {
        private readonly AppDBContext appDBContext;

        public FormQuestion(AppDBContext context)
        {
            this.appDBContext = context;
        }
        public List<ReviewFormQuestions> GetOrderedQuestions()
        {
            return appDBContext.ReviewFormQuestions.Include(c => c.section).Include(c => c.questionType).OrderBy(c => c.section.id).ToList();
        }

        public ReviewFormQuestions GetQuestionById(int questionId)
        {
            return appDBContext.ReviewFormQuestions.FirstOrDefault(c => c.id == questionId);
        }
    }
}
