using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RankUp.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace RankUp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IUserRepository userRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ICritiqueRepository critiqueRepository;

        private readonly IHttpContextAccessor contextAccessor;

        public UserController(UserManager<User> userManager, IUserRepository userRepository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor, ICritiqueRepository critiqueRepository)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.critiqueRepository = critiqueRepository;

            this.contextAccessor = contextAccessor;
        }
        [HttpGet]
        public IActionResult UserProfile()
        {
            var userid = userManager.GetUserId(HttpContext.User);
            var user = userRepository.GetUser(userid);

            #region Get All user's details

            ViewBag.cvRequests = userRepository.GetCVRequests(userid);
            ViewBag.interviewRequests = userRepository.GetInterviewRequests(userid);
            ViewBag.linkedInRequests = userRepository.GetLinkedInRequests(userid);
            ViewBag.pendingRequests = userRepository.GetPendingRequests(userid);

            #endregion

            return View(user);
        }

        [HttpPost]
        public IActionResult UploadCV(IFormFile CVFile)
        {
            //contextAccessor.HttpContext.Session.GetString("User");

            var userid = userManager.GetUserId(HttpContext.User);
            var user = userRepository.GetUser(userid);
            var cvpath = user.CV;
            if (cvpath != null)
                System.IO.File.Delete(cvpath);

            string CVPath = Path.Combine(webHostEnvironment.WebRootPath, "CVs");
            string fileName = Guid.NewGuid().ToString() + "_" + CVFile.FileName;
            CVFile.CopyTo(new FileStream(Path.Combine(CVPath, fileName), FileMode.Create));
            userRepository.updateCV(user, fileName);

            return RedirectToAction("UserProfile");

        }

        [HttpPost]
        public async Task<IActionResult> UploadCVAndRequestReview(IFormFile CVFile)
        {
            var userid = userManager.GetUserId(HttpContext.User);
            var user = userRepository.GetUser(userid);

            string CVPath = Path.Combine(webHostEnvironment.WebRootPath, "CVs");
            string fileName = Guid.NewGuid().ToString() + "_" + CVFile.FileName;
            CVFile.CopyTo(new FileStream(Path.Combine(CVPath, fileName), FileMode.Create));
            userRepository.updateCV(user, fileName);

            var result = await critiqueRepository.AddCVReviewAsync(userid);

            // don't use viewBag with redirect, use it with return View() only: to avoid returning NULL vslues
            //ViewBag.uploadCvAndRequestReview = true;
            // instead: use TempData
            TempData["uploadCvAndRequestReview"] = result;
            return RedirectToAction("UserProfile");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var userid = userManager.GetUserId(HttpContext.User);
            var currentUser = userRepository.GetUser(userid);
            return View(currentUser);
        }

        [HttpPost]
        public IActionResult Edit(User editedUser)
        {
            if (ModelState.IsValid)
            {
                userRepository.Update(editedUser);
                return RedirectToAction("UserProfile");
            }
            // if not valid: stay in the same view
            return View(editedUser);
        }


    }
}
