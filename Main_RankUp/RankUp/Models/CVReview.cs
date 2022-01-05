using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class CVReview : ICVReview
    {
        private readonly AppDBContext appDBContext;

        public CVReview (AppDBContext context)
        {
            this.appDBContext = context;
        }
        public ReviewContent Add(ReviewContent newContent)
        {
            appDBContext.reviewContent.Add(newContent);
            appDBContext.SaveChanges();

            return newContent;
        }
    }
}
