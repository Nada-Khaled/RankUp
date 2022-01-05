using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class ReviewRequestsRepository : IReviewRequestsRepository
    {
        AppDBContext context;
        //private readonly IStatisticalDataRepository statisticalDataRepository;

        public ReviewRequestsRepository(AppDBContext context)//, IStatisticalDataRepository statisticalDataRepository)
        {
            this.context = context;
            //this.statisticalDataRepository = statisticalDataRepository;
        }

        // need to handle if null returned
        public ReviewRequests GetLatestCVRequest()
        {
            ReviewRequests latestCV = context.reviewRequests.Where(c => c.requestType == "CV" && c.status == "submitted").Include(c => c.user).OrderBy(c => c.RequestDate).First();
            //latestCV.status = "In progress";
            //context.reviewRequests.Update(latestCV);
            //context.SaveChanges();
            return latestCV;
        }

        // need to handle if null returned
        public ReviewRequests GetLatestInterviewRequest()
        {
            ReviewRequests latestInterview = context.reviewRequests.Where(c => c.requestType == "interview" && c.status == "submitted").Include(c => c.user).OrderBy(c => c.RequestDate).First();
            //latestInterview.status = "In progress";
            //context.reviewRequests.Update(latestInterview);
            //context.SaveChanges();
            return latestInterview;
        }
        // need to handle if null returned
        public ReviewRequests GetLatestLinkedInRequest()
        {
            ReviewRequests latestLinkedIn = context.reviewRequests.Where(c => c.requestType == "linkedin" && c.status == "submitted").Include(c => c.user).OrderBy(c => c.RequestDate).First();
            //latestLinkedIn.status = "In progress";
            //context.reviewRequests.Update(latestLinkedIn);
            //context.SaveChanges();
            return latestLinkedIn;
        }
        public bool CheckAvailableCVs()
        {
            int availableRequests = context.reviewRequests.Where(c => c.requestType == "CV" && c.status == "submitted").Count();
            if (availableRequests != 0)
                return true;
            return false;
        }
        public int GetCVReviewCount()
        {
            return context.reviewRequests.Where(c => c.requestType == "CV" && c.status != "approved").Count();
        }
        public int GetLinkedInReviewCount()
        {
            return context.reviewRequests.Where(c => c.requestType == "linkedin" && c.status != "approved").Count();
        }
        public int GetIVReviewCount()
        {
            return context.reviewRequests.Where(c => c.requestType == "interview" && c.status != "approved").Count();
        }
        
        public int getActiveUsersCount()
        {
            return context.reviewRequests.Include(c => c.user).GroupBy(c => c.user.Id).Count();
        }
        public int GetTotalReviewdCVRequests()
        {
            return context.reviewRequests.Where(c => c.requestType == "CV" && c.status != "submitted").Count();
        }
        public int GetTotalReviewdIVRequests()
        {
            return context.reviewRequests.Where(c => c.requestType == "interview" && c.status != "submitted").Count();
        }
        public int GetTotalReviewdLinkedInRequests()
        {
            return context.reviewRequests.Where(c => c.requestType == "linkedin" && c.status != "submitted").Count();
        }

        public int GetTotalSubmittedRequestsWithinAWeek()
        {
            DateTime startDate = System.DateTime.Now.AddDays(-7);

            return context.reviewRequests.Where(c => c.status == "submitted" && c.RequestDate >= startDate && c.RequestDate <= System.DateTime.Now).Count();
        }

        public int GetTotalCompletedRequestsWithinAWeek()
        {
            DateTime startDate = System.DateTime.Now.AddDays(-7);

            return context.reviewRequests.Where(c => c.status == "approved" && c.RequestDate >= startDate && c.RequestDate <= System.DateTime.Now).Count();
        }
        public int GetTotalAverageResponseTimeWithinAWeek()
        {
            DateTime startDate = System.DateTime.Now.AddDays(-7);
            DateTime defaultDate = new DateTime(0001, 01, 01, 12, 00, 00);

            var datesList = context.reviewRequests.Where(c => c.status == "approved" && c.RequestDate >= startDate && c.RequestDate <= System.DateTime.Now && c.approvedDate != defaultDate).Select(c => new { key = c.RequestDate, val = c.approvedDate }).ToList();

            int avgDays = 0;

            foreach (var element in datesList)
            {
                avgDays += (element.val - element.key).Days;
            }
            return avgDays;
        }

        public int GetUserRetentionWithinAWeek()
        {
            DateTime startDate = System.DateTime.Now.AddDays(-7);

            return context.reviewRequests.Where(c => c.RequestDate >= startDate && c.RequestDate <= System.DateTime.Now).Include(c => c.user).GroupBy(c => c.user.Id).Where(c => c.Count() > 1).Count();
        }
        public Dictionary<string, List<int>> GetRequestsHistory()
        {
            // the returned data structure is a list:
            // [
            // {key = {requestType = "CV", Month = 10}, val = 1}
            // {key = {requestType = "CV", Month = 9}, val = 3}
            // {key = {requestType = "LinkedIn", Month = 10}, val = 2}
            // {key = {requestType = "interview", Month = 9}, val = 1}
            // ]
            var x = context.reviewRequests.Where(c=>c.RequestDate.Month >= System.DateTime.Now.Month - 5).GroupBy(c => new { c.requestType, c.RequestDate.Month }).Select(c => new { key = c.Key, val = c.Count() }).ToList();
            Dictionary<string, List<int>> numOfTypeOccurrences = new Dictionary<string, List<int>>();

            #region construct history for the latest 5 months

            // can we pass number of months as a parameter ?(yes)
            List<int> desiredMonths = new List<int>();
            desiredMonths.AddRange(Enumerable.Range(System.DateTime.Now.Month - 5, 5));

            //distinct values in request review type: { "CV", "interview", "linkedin" }
            List<string> requestTypes = context.reviewRequests.Select(c => c.requestType).Distinct().ToList();
            // ==> Simplify the data structure of the returned data from DB
            // the new structure is:
            // { ("CV", 7), 1}
            // { ("CV", 8), 3}
            // { ("interview", 7), 2}
            var result = x.ToDictionary(x => (x.key.requestType, x.key.Month), x => x.val);


            for (int i = 0; i < requestTypes.Count; i++)
            {
                // this list will contain number of occurrences for each type for each month
                List<int> occurrences = new List<int>();
                for (int j = 0; j < desiredMonths.Count; j++)
                {
                    // Ex of kvp: ("CV", 7)
                    var kvp = (requestTypes[i], desiredMonths[j]);

                    if (result.ContainsKey(kvp))
                    {
                        occurrences.Add(result[kvp]);
                    }
                    else
                    {
                        occurrences.Add(0);
                    }

                }
                numOfTypeOccurrences[requestTypes[i]] = occurrences;
            }
            #endregion
            return numOfTypeOccurrences;
        }


    }
}
