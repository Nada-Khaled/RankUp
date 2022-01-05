using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class Form : IForm
    {
        AppDBContext appDBContext;

        public Form(AppDBContext context)
        {
            this.appDBContext = context;
        }
        public List<ReviewFormOptions> GetOrderedOptionsByQuestion()
        {
            return appDBContext.ReviewFormOptions.Include(c => c.question).OrderBy(c => c.question.id).ToList();
        }

        public List<ReviewFormQuestions> GetOrderedQuestions()
        {
            return appDBContext.ReviewFormQuestions.Include(c => c.section).Include(c => c.questionType).OrderBy(c => c.section.id).ToList();
        }

        public List<ReviewFormSections> GetOrderedSections()
        {
            return appDBContext.ReviewFormSections.OrderBy(c => c.id).ToList();
        }

        public ReviewFormQuestions GetQuestionById(int questionId)
        {
            return appDBContext.ReviewFormQuestions.FirstOrDefault(c => c.id == questionId);
        }

        public ReviewFormSections GetSectionById(int sectionId)
        {
            return appDBContext.ReviewFormSections.FirstOrDefault(c => c.id == sectionId);
        }
    }
}
