using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class StatisticalDataRepository : IStatisticalDataRepository
    {
        private readonly AppDBContext context;
        private readonly IReviewRequestsRepository reviewRequestsRepository;

        public StatisticalDataRepository(AppDBContext context, IReviewRequestsRepository reviewRequestsRepository)
        {
            this.context = context;
            this.reviewRequestsRepository = reviewRequestsRepository;
        }
     
        public DateTime GetAverageResponseTime()
        {
            try
            {
                return context.statisticalData.Where(c => c.discription == "average response time").First().updateDate;
            }
            catch
            {
                StatisticalData statisticalData = new StatisticalData
                {
                    discription = "average response time",
                    value = 0,
                    oldValue = 0,
                    updateDate = System.DateTime.Now
                };
                context.statisticalData.Add(statisticalData);
                context.SaveChanges();
                return statisticalData.updateDate;
            }
        }
        public void UpdateAverageResponseTime(DateTime newDate)
        {
            context.statisticalData.Where(c => c.discription == "average response time").First().updateDate = newDate;

            context.SaveChanges();

        }
        public int GetAverageResponseTimeValue()
        {
            try
            {

            return context.statisticalData.Where(c => c.discription == "average response time").Select(c => c.value).First();
            }
            catch
            {
                StatisticalData statisticalData = new StatisticalData
                {
                    discription = "average response time",
                    value = 0,
                    oldValue = 0,
                    updateDate = System.DateTime.Now
                };
                context.statisticalData.Add(statisticalData);
                context.SaveChanges();
                return statisticalData.value;
            }
        }
        public void UpdateAverageResponseTimeValue(int value)
        {
            context.statisticalData.Where(c => c.discription == "average response time").First().value = context.statisticalData.Where(c => c.discription == "average response time").First().value;
            context.statisticalData.Where(c => c.discription == "average response time").First().value = value;

            context.SaveChanges();

        }
        
        public DateTime GetLatestCompletedRequestDate()
        {
            try
            {
                return context.statisticalData.Where(c => c.discription == "latest completed request").First().updateDate;
            }
            catch
            {
                StatisticalData statisticalData = new StatisticalData
                {
                    discription = "latest completed request",
                    value = 0,
                    oldValue = 0,
                    updateDate = System.DateTime.Now
                };
                context.statisticalData.Add(statisticalData);
                context.SaveChanges();

                return statisticalData.updateDate;
            }
        }
        public void UpdateLatestCompletedRequestDate(DateTime newDate)
        {
            context.statisticalData.Where(c => c.discription == "latest completed request").First().updateDate = newDate;

            context.SaveChanges();

        }
        public int GetLatestCompletedRequestValue()
        {
            try
            {

                return context.statisticalData.Where(c => c.discription == "latest completed request").Select(c => c.value).First();
            }
            catch
            {
                StatisticalData statisticalData = new StatisticalData
                {
                    discription = "latest completed request",
                    value = 0,
                    oldValue = 0,
                    updateDate = System.DateTime.Now
                };
                context.statisticalData.Add(statisticalData);
                context.SaveChanges();

                return statisticalData.value;
            }
        }
        public void UpdateLatestCompletedRequestValue(int value)
        {
            context.statisticalData.Where(c => c.discription == "latest completed request").First().oldValue = context.statisticalData.Where(c => c.discription == "latest completed request").First().value;
            context.statisticalData.Where(c => c.discription == "latest completed request").First().value = value;

            context.SaveChanges();

        }

        public DateTime GetLatestSubmittedRequestDate()
        {
            try
            {
                return context.statisticalData.Where(c => c.discription == "latest submitted request").First().updateDate;
            }
            catch
            {
                StatisticalData statisticalData = new StatisticalData
                {
                    discription = "latest submitted request",
                    value = 0,
                    oldValue = 0,
                    updateDate = System.DateTime.Now
                };
                context.statisticalData.Add(statisticalData);
                context.SaveChanges();
                return statisticalData.updateDate;
            }
        }                                       
        public void UpdateLatestSubmittedRequestDate(DateTime newDate)
        {
            context.statisticalData.Where(c => c.discription == "latest submitted request").First().updateDate = newDate;

            context.SaveChanges();

        }
        public int GetLatestSubmittedRequestValue()
        {
            try
            {
                return context.statisticalData.Where(c => c.discription == "latest submitted request").First().value;
            }
            catch
            {
                StatisticalData statisticalData = new StatisticalData
                {
                    discription = "latest submitted request",
                    value = 0,
                    oldValue = 0,
                    updateDate = System.DateTime.Now
                };
                context.statisticalData.Add(statisticalData);
                context.SaveChanges();
                return statisticalData.value;
            }
        }
        public void UpdateLatestSubmittedRequestValue(int value)
        {
            context.statisticalData.Where(c => c.discription == "latest submitted request").First().oldValue = context.statisticalData.Where(c => c.discription == "latest submitted request").First().value;
            context.statisticalData.Where(c => c.discription == "latest submitted request").First().value = value;

            context.SaveChanges();

        }

        public DateTime GetUserRetentionDate()
        {
            try
            {
                return context.statisticalData.Where(c => c.discription == "user retention").First().updateDate;
            }
            catch
            {
                StatisticalData statisticalData = new StatisticalData
                {
                    discription = "user retention",
                    value = 0,
                    oldValue = 0,
                    updateDate = System.DateTime.Now
                };
                context.statisticalData.Add(statisticalData);
                context.SaveChanges();
                return statisticalData.updateDate;
            }
        }
        public void UpdateUserRetentionDate(DateTime newDate)
        {
            try
            {
                context.statisticalData.Where(c => c.discription == "user retention").First().updateDate = newDate;
                context.SaveChanges();
            }
            catch
            {
                StatisticalData statisticalData = new StatisticalData
                {
                    discription = "user retention",
                    value = 0,
                    oldValue = 0,
                    updateDate = newDate
                };
                context.statisticalData.Add(statisticalData);
                context.SaveChanges();
            }
        }
        public int GetUserRetentionValue()
        {
            try
            {
                return context.statisticalData.Where(c => c.discription == "user retention").First().value;
            }
            catch
            {
                StatisticalData statisticalData = new StatisticalData
                {
                    discription = "user retention",
                    value = 0,
                    oldValue = 0,
                    updateDate = System.DateTime.Now
                };
                context.statisticalData.Add(statisticalData);
                context.SaveChanges();
                return statisticalData.value;
            }
        }
        public void UpdateUserRetentionValue(int value)
        {
            try
            {
                context.statisticalData.Where(c => c.discription == "user retention").First().oldValue = context.statisticalData.Where(c => c.discription == "user retention").First().value;
                context.statisticalData.Where(c => c.discription == "user retention").First().value = value;
                context.SaveChanges();
            }
            catch
            {
                StatisticalData statisticalData = new StatisticalData
                {
                    discription = "user retention",
                    value = value,
                    oldValue = 0,
                    updateDate = System.DateTime.Now
                };
                context.statisticalData.Add(statisticalData);
                context.SaveChanges();
            }
        }

        // Done editting
        public int GetTotalSubmittedRequestsWithinAWeek()
        {
            DateTime lastSubmittedDate = GetLatestSubmittedRequestDate();

            if (lastSubmittedDate.AddDays(7) < System.DateTime.Now)
            {
                UpdateLatestSubmittedRequestDate(System.DateTime.Now);

                int newValue = reviewRequestsRepository.GetTotalSubmittedRequestsWithinAWeek();

                UpdateLatestSubmittedRequestValue(newValue);
            }
            return context.statisticalData.Where(c => c.discription == "latest submitted request").First().value;
        }
        public int GetTotalCompletedRequestsWithinAWeek()
        {
            DateTime lastCompletedDate = GetLatestCompletedRequestDate();

            if (lastCompletedDate.AddDays(7) < System.DateTime.Now)
            {
                UpdateLatestCompletedRequestDate(System.DateTime.Now);

                int newValue = reviewRequestsRepository.GetTotalCompletedRequestsWithinAWeek();

                UpdateLatestCompletedRequestValue(newValue);
            }
            return context.statisticalData.Where(c => c.discription == "latest completed request").First().value;
        }
        public int GetTotalAverageResponseTimeWithinAWeek()
        {
            DateTime lastAvgResponseDate = GetAverageResponseTime();

            if (lastAvgResponseDate.AddDays(7) < System.DateTime.Now)
            {
                UpdateAverageResponseTime(System.DateTime.Now);

                int newValue = reviewRequestsRepository.GetTotalAverageResponseTimeWithinAWeek();

                UpdateAverageResponseTimeValue(newValue);
            }
            return context.statisticalData.Where(c => c.discription == "average response time").First().value;
        }
        public int GetUserRetentionWithinAWeek()
        {

            DateTime lastUserRetentionDate = GetUserRetentionDate();

            if (lastUserRetentionDate.AddDays(7) < System.DateTime.Now)
            {
                UpdateUserRetentionDate(System.DateTime.Now);

                int newValue = reviewRequestsRepository.GetUserRetentionWithinAWeek();

                UpdateUserRetentionValue(newValue);
            }
            return context.statisticalData.Where(c => c.discription == "user retention").First().value;
        }

        public double GetTotalSubmittedRequestsPercentage()
        {
            int currentValue = context.statisticalData.Where(c => c.discription == "latest submitted request").First().value;
            int oldValue = context.statisticalData.Where(c => c.discription == "latest submitted request").First().oldValue;

            if (oldValue == 0)
                oldValue = 1;

            double percentage = (Convert.ToDouble(currentValue) / oldValue);// * 100;

            return Convert.ToDouble(String.Format("{0:0.00}", percentage));

        }
        public double GetTotalCompletedRequestsPercentage()
        {
            int currentValue = context.statisticalData.Where(c => c.discription == "latest completed request").First().value;
            int oldValue = context.statisticalData.Where(c => c.discription == "latest completed request").First().oldValue;

            if (oldValue == 0)
                oldValue = 1;

            double percentage = (Convert.ToDouble(currentValue) / oldValue);// * 100;

            return Convert.ToDouble(String.Format("{0:0.00}", percentage));

        }
        public double GetUserRetentionPercentage()
        {
            int currentValue = context.statisticalData.Where(c => c.discription == "user retention").First().value;
            int oldValue = context.statisticalData.Where(c => c.discription == "user retention").First().oldValue;

            if (oldValue == 0)
                oldValue = 1;

            double percentage = (Convert.ToDouble(currentValue) / oldValue);// * 100;

            return Convert.ToDouble(String.Format("{0:0.00}", percentage));

        }
        public double GetTotalAverageResponseTimePercentage()
        {
            int currentValue = context.statisticalData.Where(c => c.discription == "average response time").First().value;
            int oldValue = context.statisticalData.Where(c => c.discription == "average response time").First().oldValue;

            if (oldValue == 0)
                oldValue = 1;

            double percentage = (Convert.ToDouble(currentValue) / oldValue);// * 100;

            return Convert.ToDouble(String.Format("{0:0.00}", percentage));

        }

    }
}
