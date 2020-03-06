using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
    public class SqlReviewRepository : IReviewRepository
    {
        private readonly AppDbContext context;

        public SqlReviewRepository(AppDbContext context)
        {
            this.context = context;
        }



        public Review Add(Review review)
        {
            context.Review.Add(review);
            context.SaveChanges();
            return review;
        }

        public int AverageRating()
        {
            var review5 = context.Review.Where(p => p.Rating == 5).Count();
            var review4 = context.Review.Where(p => p.Rating == 4).Count();
            var review3 = context.Review.Where(p => p.Rating == 3).Count();
            var review2 = context.Review.Where(p => p.Rating == 2).Count();
            var review1 = context.Review.Where(p => p.Rating == 1).Count();

            var total = ((5 * review5) + (4 * review4) + (3 * review3) + (2 * review2) + (1 * review1));
            var totalReviews = (review1 + review2 + review3 + review4 + review5);
            var average = total / totalReviews;

            return average;
        }

        public Review Delete(int id)
        {
            Review review = context.Review.Find(id);
            if (review != null)
            {
                context.Review.Remove(review);
                context.SaveChanges();

            }
            return review;
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return context.Review;
        }

    }
}
