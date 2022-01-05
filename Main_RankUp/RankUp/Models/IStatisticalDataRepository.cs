using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public interface IStatisticalDataRepository
    {
        public DateTime GetLatestSubmittedRequestDate();
        public void UpdateLatestSubmittedRequestDate(DateTime newDate);
        public int GetLatestSubmittedRequestValue();
        public void UpdateLatestSubmittedRequestValue(int value);

        public DateTime GetLatestCompletedRequestDate();
        public void UpdateLatestCompletedRequestDate(DateTime newDate);
        public int GetLatestCompletedRequestValue();
        public void UpdateLatestCompletedRequestValue(int value);

        public DateTime GetAverageResponseTime();
        public void UpdateAverageResponseTime(DateTime newDate);
        public int GetAverageResponseTimeValue();
        public void UpdateAverageResponseTimeValue(int value);

        public DateTime GetUserRetentionDate();
        public void UpdateUserRetentionDate(DateTime newDate);
        public int GetUserRetentionValue();
        public void UpdateUserRetentionValue(int value);

        public int GetTotalSubmittedRequestsWithinAWeek();
        public int GetTotalCompletedRequestsWithinAWeek();
        public int GetTotalAverageResponseTimeWithinAWeek();
        public int GetUserRetentionWithinAWeek();

        public double GetTotalSubmittedRequestsPercentage();
        public double GetTotalCompletedRequestsPercentage();
        public double GetUserRetentionPercentage();
        public double GetTotalAverageResponseTimePercentage();
    }
}
