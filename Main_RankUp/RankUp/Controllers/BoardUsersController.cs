using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RankUp.Models;
using RankUp.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Controllers
{
    public class BoardUsersController : Controller
    {

        private IBoardUserRepository boardUserRepository;
        private IReviewRequestsRepository reviewRequestsRepository;
        private readonly ICVReview CvReview;
        private readonly IForm form;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ITaskRepository taskRepository;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> siginManager;
        private readonly IUserRepository userRepository;
        private readonly IStatisticalDataRepository statisticalDataRepository;

        public BoardUsersController(ICVReview cVReview, IBoardUserRepository boardUser, IForm form,
            IReviewRequestsRepository reviewRequestsRepository, IWebHostEnvironment webHostEnvironment,
            ITaskRepository taskRepository, UserManager<User> userManager, SignInManager<User> signInManager,
            IUserRepository userRepository, IStatisticalDataRepository statisticalDataRepository)
        {
            this.boardUserRepository = boardUser;
            this.reviewRequestsRepository = reviewRequestsRepository;
            this.CvReview = cVReview;
            this.form = form;
            this.webHostEnvironment = webHostEnvironment;
            this.taskRepository = taskRepository;
            this.userManager = userManager;
            this.siginManager = signInManager;
            this.userRepository = userRepository;
            this.statisticalDataRepository = statisticalDataRepository;
        }

        public IActionResult Index()
        {
            var userid = userManager.GetUserId(HttpContext.User);
            ViewBag.AllTasks = taskRepository.GetTasks(userid);
            ViewBag.pendingCVReview = reviewRequestsRepository.GetCVReviewCount();
            ViewBag.pendingLinkedinReview = reviewRequestsRepository.GetLinkedInReviewCount();
            ViewBag.pendingIVReview = reviewRequestsRepository.GetIVReviewCount();
            ViewBag.activeHR = boardUserRepository.GetActiveHR();
            ViewBag.activeUsersCount = reviewRequestsRepository.getActiveUsersCount();
            ViewBag.totalReviewdCVRequests = reviewRequestsRepository.GetTotalReviewdCVRequests();
            ViewBag.totalReviewdIVRequests = reviewRequestsRepository.GetTotalReviewdIVRequests();
            ViewBag.totalReviewdLinkedInRequests = reviewRequestsRepository.GetTotalReviewdLinkedInRequests();
            
            var requestsHistory = reviewRequestsRepository.GetRequestsHistory();

            // trying to create the same data structure as in chart.js file
            var chartDataSet = new List<Object>();
            Random random = new Random();
            HashSet<string> distinctColors = new HashSet<string>();

            foreach (var element in requestsHistory)
            {
                // to generate a random distinct color for each chart line,
                // save the newly generated color in a set
                string color;
                do
                {
                    //color = Color.FromArgb(0, random.Next(100, 255), random.Next(100, 255), random.Next(100, 255));
                    color = String.Format("#{0:X6}", random.Next(0x1000000)); // = "#A197B9"

                } while (distinctColors.Contains(color));

                distinctColors.Add(color);
            
                var chartLineData = new
                {
                    label = element.Key,
                    data = element.Value,
                    borderColor = color,
                    fill = false,
                    borderWidth = 2,
                };

                chartDataSet.Add(chartLineData);
            }

            ViewBag.requestsHistory = chartDataSet;


            var usersCountries = userRepository.GetUsersCountries();
            List<int> countUsers = new List<int>();
            List<string> countCountries = new List<string>();
            foreach(var element in usersCountries)
            {
                countCountries.Add(element.Item1);
                countUsers.Add(element.Item2);
            }
            ViewBag.usersCount = countUsers;
            ViewBag.countriesCount = countCountries;


            #region number of submitted requests and their percentage

            // 1)
            var submittedRequestsWithinAWeek = statisticalDataRepository.GetTotalSubmittedRequestsWithinAWeek();
            var submittedRequestsPercentage = statisticalDataRepository.GetTotalSubmittedRequestsPercentage();

            ViewBag.submittedRequestsWithinAWeek = submittedRequestsWithinAWeek;
            ViewBag.submittedRequestsPercentage = submittedRequestsPercentage;


            #endregion

            #region number of completed requests and their percentage

            var completedRequestsWithinAWeek = statisticalDataRepository.GetTotalCompletedRequestsWithinAWeek();
            var completedRequestsPercentage = statisticalDataRepository.GetTotalCompletedRequestsPercentage();

            ViewBag.completedRequestsWithinAWeek = completedRequestsWithinAWeek;
            ViewBag.completedRequestsPercentage = completedRequestsPercentage;

            #endregion

            #region user retention

            var userRetention = statisticalDataRepository.GetUserRetentionWithinAWeek();
            var userRetentionPercentage = statisticalDataRepository.GetUserRetentionPercentage();

            ViewBag.userRetention = userRetention;
            ViewBag.userRetentionPercentage = userRetentionPercentage;

            #endregion


            #region avg response time and its percentage

            var averageResponseTime = statisticalDataRepository.GetTotalAverageResponseTimeWithinAWeek();
            var averageResponseTimePercentage = statisticalDataRepository.GetTotalAverageResponseTimePercentage();

            ViewBag.avgResponseTimeWithinAWeek = averageResponseTime;
            ViewBag.avgResponseTimePercentage = averageResponseTimePercentage;

            #endregion

            // exclude el HR members 
            ViewBag.allUsersCount = userRepository.GetAllUsers().Count();

            return View();
        }
        [HttpGet]
        public IActionResult ViewBoardUsers()
        {
            ViewBag.AllBoardUsers = boardUserRepository.GetAllBoardUsers();
            return View();
        }

        [HttpGet]
        public IActionResult EditBoardUser(int boardUserId)
        {
            BoardUsers boardUser = boardUserRepository.GetBoardUserById(boardUserId);
            return View(boardUser);
        }

        [HttpPost]
        public IActionResult EditBoardUser(BoardUsers UpdatedBoardUser)
        {
            if (ModelState.IsValid)
            {
                boardUserRepository.Update(UpdatedBoardUser);

                return RedirectToAction("ViewBoardUsers");
            }

            return View(UpdatedBoardUser);
        }
    
        [HttpGet]
        public IActionResult AddNewHRMember()
        {
            return View();
        }    
        [HttpPost]
        public async Task<IActionResult> AddNewHRMember(HRMember NewBoardUser)
        {
            ViewBag.addNewHR = false;

            // Setting newBoardUser's password to default value: RankUp@1234,
            // then notify the admin with it.
            NewBoardUser.password = "RankUp@1234";

            User newUser = new User
            {
                firstName = NewBoardUser.firstName,
                lastName = NewBoardUser.lastName,
                UserName = NewBoardUser.email,
                Email = NewBoardUser.email,
                PhoneNumber = NewBoardUser.phone,
                gender = NewBoardUser.gender,
            };
            var result = await userManager.CreateAsync(newUser, NewBoardUser.password);
            if (result.Succeeded)
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
                var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = newUser.Id, token = token }, Request.Scheme);
                WelcomeRequest welcomeRequest = new WelcomeRequest { link = confirmationLink, UserName = newUser.firstName, mail = newUser.Email };
                //bool mailResult = await SendWelcomeMail(welcomeRequest);

                BoardUsers boardUser = new BoardUsers
                {
                    isAdmin = NewBoardUser.isAdmin,
                    isAvailable = NewBoardUser.isAvailable,
                    user = newUser,
                    CVsReviewed = 0,

                };
                
                boardUserRepository.Add(boardUser);

                ViewBag.addNewHR = true;

                return RedirectToAction("ViewBoardUsers");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();

        }
    
        [HttpGet]
        public IActionResult ViewRequests()
        {
            ViewBag.latestCV = reviewRequestsRepository.GetLatestCVRequest();
            ViewBag.latestInterview = reviewRequestsRepository.GetLatestInterviewRequest();
            ViewBag.latestLinkedIn = reviewRequestsRepository.GetLatestLinkedInRequest();
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
            { }
            return RedirectToAction("Index");
        }

        public IActionResult CheckAvailableCVs()
        {
            bool availableRequests = reviewRequestsRepository.CheckAvailableCVs();
            if (availableRequests)
            {
                return Json("CV");
            }
            return Json("No CV");
        }
        public IActionResult GetLatestCV()
        {
            ReviewRequests request = reviewRequestsRepository.GetLatestCVRequest();
            TempData["requestid"] = request.id;
            return File(System.IO.File.ReadAllBytes(Path.Combine(webHostEnvironment.WebRootPath, "CVs", request.user.CV)), "application/pdf", request.user.firstName + ".pdf");
        }

        public IActionResult AddTask(string taskContent)
        {
            var userid = userManager.GetUserId(HttpContext.User);
            var user = userRepository.GetUser(userid);
            ToDoList newTask = new ToDoList
            {
                task = taskContent,
                isDone = false,
                boardUser = user
            };
            bool result =  taskRepository.AddNewTask(newTask);
            if (result) return Json(newTask.id.ToString()); else return Json("error");
        }
        public IActionResult UpdateTaskStatus(string taskId, bool taskStatus)
        {
            bool result = taskRepository.UpdateTaskStatus(Convert.ToInt32(taskId), taskStatus);
            if (result) return Json("OK"); else return Json("error");
        }
        public IActionResult DeleteTask(string taskId)
        {
            bool result = taskRepository.DeleteTask(Convert.ToInt32(taskId));
            if (result) return Json("OK"); else return Json("error");
        }

        [HttpGet]
        public IActionResult DeleteBoardUser(string deletedBoardUserId)
        {
            var x = boardUserRepository.GetAllBoardUsers().Count;
            bool result = boardUserRepository.DeleteBoardUser(Convert.ToInt32(deletedBoardUserId));

            ViewBag.AllBoardUsers = boardUserRepository.GetAllBoardUsers();

            if (result) return Json("OK"); else return Json("error");
        }

        public async Task <IActionResult> ResetBoardUserPassword(string boardUserId)
        {
            bool result = await boardUserRepository.ResetBoardUserPasswordAsync(Convert.ToInt32(boardUserId));
            if (result) return Json("OK"); else return Json("error");
        }

        public IActionResult FilterBoardUsers(IFormCollection collection)
        {

            var userName = collection["userName"];
            var isAdmin = collection["isAdmin"];
            var isAvailable = collection["isAvailable"];

            bool admin, available;

            if (isAdmin == "on")
                admin = true;
            else
                admin = false;

            if (isAvailable == "on")
                available = true;
            else
                available = false;

            List<BoardUsers> filteredBoardUsers = boardUserRepository.FilterBoardUsers(userName, admin, available);

            ViewBag.AllBoardUsers = filteredBoardUsers;

            return View("ViewBoardUsers");
        }


    }
}
