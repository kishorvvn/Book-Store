using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
   public interface IReviewRepository
    {
        IEnumerable<Review> GetAllReviews();
        Review Add(Review review);
        Review Delete(int id);
        int AverageRating();
        
    }
}
