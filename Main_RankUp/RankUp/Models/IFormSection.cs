using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public interface IFormSection
    {

        public List<ReviewFormSections> GetOrderedSections();
        public ReviewFormSections GetSectionById(int sectionId);
    }
}
