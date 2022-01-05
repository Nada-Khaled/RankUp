using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public interface ICritiqueRepository
    {
        //public Task<string> AddCVReviewAsync();
        public Task<string> AddCVReviewAsync(string userId);
    }
}
