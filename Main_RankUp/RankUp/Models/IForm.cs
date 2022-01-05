using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public interface IForm
    {
        public List<ReviewFormSections> GetOrderedSections();
        public ReviewFormSections GetSectionById(int sectionId);

        public List<ReviewFormQuestions> GetOrderedQuestions();
        public ReviewFormQuestions GetQuestionById(int questionId);
        public List<ReviewFormOptions> GetOrderedOptionsByQuestion();

    }
}
