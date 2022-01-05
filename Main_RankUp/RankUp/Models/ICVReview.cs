using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public interface ICVReview
    {

        ReviewContent Add(ReviewContent newContent);
    }
}
