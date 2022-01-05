using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using RankUp.Models;
using RankUp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace RankUp.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMailService mailService;

        public AccountController(IUserRepository userRepository,IWebHostEnvironment webHostEnvironment,
                                 UserManager<User>userManager,SignInManager<User>signInManager, IMailService mailService)
        {
            this.userRepository = userRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mailService = mailService;
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(string mail,string password,bool rememberMe)
        {
            var result = await signInManager.PasswordSignInAsync(mail, password, rememberMe, false);
            var test = await signInManager.GetExternalLoginInfoAsync();
            
            if (result.Succeeded)
            {
                return RedirectToAction("UserProfile", "User");
            }

            return View();
        }
        [HttpGet]
        public IActionResult LogIn()
        {
           
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            string fileName = null;
            if (registerModel.CV != null)
            {
                string CVPath = Path.Combine(webHostEnvironment.WebRootPath,"CVs");
                fileName = Guid.NewGuid().ToString() + "_" + registerModel.CV.FileName;
                registerModel.CV.CopyTo(new FileStream(Path.Combine(CVPath,fileName), FileMode.Create));
            }
            User newUser = new User
            {
                firstName = registerModel.firstName,
                lastName = registerModel.lastName,
                UserName = registerModel.email,
                Email = registerModel.email,
                PhoneNumber = registerModel.phone,
                gender = registerModel.gender,
                CV = fileName,
            };
            var result = await userManager.CreateAsync(newUser, registerModel.password);
            if (result.Succeeded)
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
                var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = newUser.Id, token = token }, Request.Scheme);
                WelcomeRequest welcomeRequest = new WelcomeRequest { link = confirmationLink, UserName = newUser.firstName,mail=newUser.Email };
                //bool mailResult = await SendWelcomeMail(welcomeRequest);
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }

        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }
            ViewBag.ErrorTitle = "Cannot confirm your Email";
            return Content("Error");
        }
        private async Task<bool> sendEmailAsync(MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpPost("welcome")]
        public async Task<bool> SendWelcomeMail([FromForm] WelcomeRequest request)
        {
            try
            {
                await mailService.SendWelcomeEmailAsync(request);
                return true;
            }
            catch
            {

                return false;
            }

        }

        [HttpGet]
        public IActionResult QuickRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> QuickRegister(RegisterModel registerModel)
        {
            // First check for reCaptcha

            var captchaResponse = Request.Form["g-recaptcha-response"];
            if (string.IsNullOrWhiteSpace(captchaResponse))
                return View();
            else
            {
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
                else
                {

                    string fileName = null;
                    try
                    {
                        if (registerModel.CV != null)
                        {
                            string CVPath = Path.Combine(webHostEnvironment.WebRootPath, "CVs");
                            fileName = Guid.NewGuid().ToString() + "_" + registerModel.CV.FileName;
                            registerModel.CV.CopyTo(new FileStream(Path.Combine(CVPath, fileName), FileMode.Create));
                        }
                        User newUser = new User
                        {
                            firstName = registerModel.firstName,
                            lastName = registerModel.lastName,
                            UserName = registerModel.email,
                            Email = registerModel.email,
                            PhoneNumber = registerModel.phone,
                            gender = registerModel.gender,
                            CV = fileName,
                        };
                        var result = await userManager.CreateAsync(newUser, registerModel.password);
                        if (result.Succeeded)
                        {
                            var token = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
                            var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = newUser.Id, token = token }, Request.Scheme);
                            WelcomeRequest welcomeRequest = new WelcomeRequest { link = confirmationLink, UserName = newUser.firstName, mail = newUser.Email };

                            //bool mailResult = await SendWelcomeMail(welcomeRequest);

                            //return RedirectToAction("Index", "Home");
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        // To stay signed in and navigate immediatly to his profile without the need to re-login
                        var signInResult = await signInManager.PasswordSignInAsync(registerModel.email, registerModel.password, true, false);

                        if (signInResult.Succeeded)
                            return RedirectToAction("UserProfile", "User");

                        return View();
                    }
                    catch (Exception e)
                    {

                        throw;
                        //return View();

                    }
                }
            }
        }

    }
}
