using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class CvReviewRequest : ICvReviewRequest
    {
        private readonly AppDBContext appDBContext;
        public CvReviewRequest(AppDBContext context)
        {
            this.appDBContext = context;
        }

        public ReviewRequests GetLatestRequest()
        {
            try
            {
                var request = appDBContext.reviewRequests.Where(c => c.requestType == "CV" && c.status == "submitted").Include(c => c.user).OrderBy(c => c.RequestDate).First();
                request.status = "In progress";
                appDBContext.reviewRequests.Update(request);
                appDBContext.SaveChanges();

                return request;
            }
            catch
            {
                return null;
            }
        }

        public bool CheckAvailableCVs()
        {
            int availableRequests = appDBContext.reviewRequests.Where(c => c.requestType == "CV" && c.status == "submitted").Count();
            if (availableRequests != 0)
                return true;
            return false;
        }
    }
}
