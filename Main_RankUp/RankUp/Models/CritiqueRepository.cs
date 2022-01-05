using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RankUp.Models.IMailService;

namespace RankUp.Models
{
    public class CritiqueRepository : Controller, ICritiqueRepository
    {
        private readonly AppDBContext context;
        private readonly IMailService mailService;
        private readonly UserManager<User> userManager;

        private readonly IHttpContextAccessor contextAccessor;

        public CritiqueRepository(AppDBContext context,IMailService mailService, UserManager<User> userManager, IHttpContextAccessor contextAccessor)
        {
            this.context = context;
            this.mailService = mailService;
            this.userManager = userManager;

            this.contextAccessor = contextAccessor;
        }

        public async Task<string> AddCVReviewAsync(string userId)
        {
            //contextAccessor.HttpContext.Session.GetString("User");

            //string userId = userManager.GetUserId(HttpContext.User);

            if (!string.IsNullOrEmpty(userId))
            {
                var userReviews = context.reviewRequests.Where(c => c.user.Id == userId && c.status == "submitted" && c.requestType == "CV").Count();
                if (userReviews == 0)
                {
                    var monthReviews = context.reviewRequests.Where(c => c.user.Id == userId && c.RequestDate.Month == DateTime.Now.Month && c.requestType == "CV").Count();
                    int maxReviews = context.baseData.Find(1).maxCVReviewPerMonth;
                    if (monthReviews <= maxReviews)
                    {
                        var cvToBeReviewed = context.reviewRequests.Where(c => c.status == "submited").Count();
                        var HrNumber = context.boardUsers.Where(c => c.isAvailable).Count();
                        int days = 0;
                        if (cvToBeReviewed == 1) { days = 1; }
                        else
                        {
                            try
                            {
                                days = cvToBeReviewed / (HrNumber * 5);
                                if (days <= 0) days = 1;
                            }
                            catch
                            {
                                days = 5;
                            }
                        }
                        var newReview = new ReviewRequests
                        {
                            approvedBy = null,
                            status = "submitted",
                            reviewer = null,
                            user = context.Users.Find(userId),
                            RequestDate = System.DateTime.Now,
                            requestType = "CV",
                            Deadline = System.DateTime.Now.AddDays(days)
                        };
                        context.reviewRequests.Add(newReview);
                        context.SaveChanges();
                        var userFirstName = context.Users.Find(userId).firstName;
                        var userEmail = context.Users.Find(userId).Email;
                        var requestID = newReview.id;
                        
                        var request = new MailRequest
                        {
                            Subject = "CV Review Confirmation",
                            Body = "Hello " + userFirstName + ",\r\n"
                            + "Your CV Review request was succefully submitted and your CV Review request ID is: " + requestID +
                            ".\r\nIts expcted from us to send the review to you after " + days.ToString() + " Day(s).\r\n",
                            ToEmail = userEmail
                        };
                        //await mailService.SendEmailAsync(request);
                        return requestID.ToString();
                    }
                    else return "exccceded max reviews per month";
                }
                else return "user already has a submitted review";
            }
            else return "User can't be empty";
        }
    }
}
