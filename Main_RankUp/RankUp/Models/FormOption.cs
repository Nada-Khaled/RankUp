using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class FormOption : IFormOption
    {
        private readonly AppDBContext appDBContext;

        public FormOption(AppDBContext context)
        {
            this.appDBContext = context;
        }
        public List<ReviewFormOptions> GetOrderedOptionsByQuestion()
        {
            return appDBContext.ReviewFormOptions.Include(c => c.question).OrderBy(c => c.question.id).ToList();
        }
    }
}
