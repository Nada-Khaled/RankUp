using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RankUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RankUp.Controllers
{
    public class CritiqueController : Controller
    {
        private readonly ICritiqueRepository critiqueRepository;
        public CritiqueController(ICritiqueRepository critiqueRepository)
        {
            this.critiqueRepository = critiqueRepository;
        }
        [HttpGet]
        public async Task<IActionResult> RequestCVReview()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var result = await critiqueRepository.AddCVReviewAsync();
            var result = await critiqueRepository.AddCVReviewAsync(userId);
            if (result.All(char.IsDigit)) return Json("requestID:"+result+"");
            else return Json("error: "+result);
        }
    }
}
