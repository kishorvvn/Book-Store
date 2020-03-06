using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
    public class MockReviewRepository : IReviewRepository
    {
        private List<Review> _reviewList;
        public MockReviewRepository()
        {
            _reviewList = new List<Review>()
            {
                new Review() {Id = 1, BookId = 2, Rating = 4, ReviewComments="This is a nice book"},
                 new Review() {Id = 2, BookId = 2, Rating = 5, ReviewComments="This is a wonderfull book"}
            };
        }

        public Review Add(Review review)
        {
            review.Id = _reviewList.Max(e => e.Id) + 1;
            _reviewList.Add(review);
            return review;
        }

        public int AverageRating()
        {
            var review5 = _reviewList.Where(p => p.Rating == 5).Count();
            var review4 = _reviewList.Where(p => p.Rating == 4).Count();
            var review3 = _reviewList.Where(p => p.Rating == 3).Count();
            var review2 = _reviewList.Where(p => p.Rating == 2).Count();
            var review1 = _reviewList.Where(p => p.Rating == 1).Count();

            var total = ((5 * review5) + (4 * review4) + (3 * review3) + (2 * review2) + (1 * review1));
            var totalReviews = (review1 + review2 + review3 + review4 + review5);
            var average = total / totalReviews;

            return average;
        }

        public Review Delete(int id)
        {
            Review review = _reviewList.FirstOrDefault(e => e.Id == id);
            if(review != null)
            {
                _reviewList.Remove(review);
            }
            return review;
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _reviewList;
        }

        
    }
}
