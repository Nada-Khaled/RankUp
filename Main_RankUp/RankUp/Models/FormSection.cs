using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class FormSection : IFormSection
    {

        private readonly AppDBContext appDBContext;

        public FormSection(AppDBContext context)
        {
            this.appDBContext = context;
        }
        public List<ReviewFormSections> GetOrderedSections()
        {
            return appDBContext.ReviewFormSections.OrderBy(c => c.id).ToList();
        }

        public ReviewFormSections GetSectionById(int sectionId)
        {
            return appDBContext.ReviewFormSections.FirstOrDefault(c => c.id == sectionId);
        }
    }
}
