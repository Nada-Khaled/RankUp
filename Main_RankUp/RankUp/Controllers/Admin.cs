using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RankUp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RankUp.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class Admin : Controller
    {

        private readonly ICVReview CvReview;
        private readonly IForm form;
        private readonly IReviewRequestsRepository reviewRequest;
        private readonly IWebHostEnvironment webHostEnvironment;

        public Admin(ICVReview cVReview, IForm form, IReviewRequestsRepository reviewRequest, IWebHostEnvironment webHostEnvironment)
        {
            this.CvReview = cVReview;
            this.form = form;
            this.reviewRequest = reviewRequest;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Review()
        {

            ViewBag.sections = form.GetOrderedSections();
            ViewBag.questions = form.GetOrderedQuestions();
            ViewBag.options = form.GetOrderedOptionsByQuestion();
            return View();
        }
        [HttpPost]
        public IActionResult Review(IFormCollection collection)
        {
            int requestid = Convert.ToInt32(TempData["requestid"]);
            try
            {
                ICollection<string> collectionKeys = collection.Keys;
                string cvReview = "";
                string sectionName = "";
                ReviewContent newReview = new ReviewContent();

                foreach (var key in collectionKeys)
                {
                    int optionIndex = key.ToString().IndexOf('O');
                    int questionIndex = key.ToString().IndexOf('Q');
                    int questionNumber = -1;
                    string questionName = "";

                    if (questionIndex != -1)
                    {
                        questionNumber = int.Parse(key.ToString().Substring(questionIndex + 1));
                        ReviewFormQuestions question = form.GetQuestionById(questionNumber);
                        questionName = question.name;
                    }

                    string sectionId;

                    if (optionIndex != -1)
                        sectionId = key.ToString().Substring(1, ((optionIndex - 1)));
                    else
                        sectionId = key.ToString().Substring(1, ((questionIndex - 1)));


                    ReviewFormSections section = form.GetSectionById(int.Parse(sectionId));
                    if (sectionName == "") sectionName = section.name;//first itration
                    else if (section.name != sectionName)//section ended, and this is a new section
                    {
                        if (cvReview != "")
                        {
                            newReview = new ReviewContent();
                            newReview.sectionName = sectionName;
                            newReview.cvReview = cvReview.Substring(0, cvReview.Length - 2);
                            newReview.requestReviewId = requestid;
                            CvReview.Add(newReview);
                        }
                        sectionName = section.name;
                        cvReview = "";
                    }
                    // cause the questions have "Other input" which it may be empty, so I don't want to save it in the DB
                    if (collection[key].Count == 1 && collection[key][0] == "")
                    {
                        continue;
                    }
                    else
                    {
                        foreach (var val in collection[key])
                        {
                            if (val == "other")
                                continue;
                            // if the value is for a radio button, concatenate the question name with it for more illustration
                            if (val.ToString().Length == 1 && Char.IsDigit(val.ToString()[0]))
                            {
                                cvReview += (questionName + ": ");
                            }
                            cvReview += val.ToString();
                            cvReview += ", ";
                        }
                    }
                }
                if (!string.IsNullOrEmpty(cvReview))
                {
                    newReview = new ReviewContent();
                    newReview.sectionName = sectionName;
                    newReview.cvReview = cvReview.Substring(0, cvReview.Length - 2); // to delete the unneccessary ', '
                    newReview.requestReviewId = requestid;
                    CvReview.Add(newReview);
                }
            }
            catch
            {}
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult CheckAvailableCVs()
        {
            bool availableRequests = reviewRequest.CheckAvailableCVs();
            if(availableRequests)
            {
                return Json("CV");
            }
            return Json("No CV");
        }
        public IActionResult GetLatestCV()
        {
            ReviewRequests request = reviewRequest.GetLatestCVRequest();
            TempData["requestid"] = request.id;
            return File(System.IO.File.ReadAllBytes(Path.Combine(webHostEnvironment.WebRootPath, "CVs",request.user.CV)), "application/pdf", request.user.firstName + ".pdf");
        }


        [HttpGet]
        public IActionResult TestRecaptcha()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ValidateRecaptcha(string name)
        {


            var captchaResponse = Request.Form["g-recaptcha-response"];
            string secretKey = "6Lfcbc8cAAAAAHQc_efdIsbwevwSdbaFTLtnXOfy";

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://www.google.com");

            var values = new List<KeyValuePair<string, string>>();

            values.Add(new KeyValuePair<string, string>("secret", secretKey));
            values.Add(new KeyValuePair<string, string>("response", captchaResponse));

            FormUrlEncodedContent content = new FormUrlEncodedContent(values);

            HttpResponseMessage response = client.PostAsync("/recaptcha/api/siteverify", content).Result;

            string verificationResponse = response.Content.ReadAsStringAsync().Result;
            var verificationResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(verificationResponse);


            if (verificationResult["success"] != "true")
            {
                return View();

            }

            return RedirectToAction("UserProfile", "User");

        }

    }
}
