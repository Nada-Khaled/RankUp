using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public interface IReviewRequestsRepository
    {

        public ReviewRequests GetLatestCVRequest();
        public ReviewRequests GetLatestLinkedInRequest();
        public ReviewRequests GetLatestInterviewRequest();
        public bool CheckAvailableCVs();
        public int GetCVReviewCount();
        public int GetLinkedInReviewCount();
        public int GetIVReviewCount();
        public int GetTotalReviewdCVRequests();
        public int GetTotalReviewdIVRequests();
        public int GetTotalReviewdLinkedInRequests();
        public int getActiveUsersCount();
        
        public int GetTotalSubmittedRequestsWithinAWeek();
        public int GetTotalCompletedRequestsWithinAWeek();
        public int GetTotalAverageResponseTimeWithinAWeek();
        public int GetUserRetentionWithinAWeek();

        public Dictionary<string, List<int>> GetRequestsHistory();

    }
}
