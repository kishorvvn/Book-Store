using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
    public class SqlBookAverageRatingRepository : IBookAverageRatingRepository
    {
        private readonly AppDbContext context;

        public SqlBookAverageRatingRepository(AppDbContext context)
        {
            this.context = context;
        }


        public BookAverageRating Add(BookAverageRating bookAverageRating)
        {
            context.BookAverageRatings.Add(bookAverageRating);
            context.SaveChanges();
            return bookAverageRating;
        }

        public BookAverageRating Delete(int id)
        {
            BookAverageRating rating = context.BookAverageRatings.Find(id);
            if (rating != null)
            {
                context.BookAverageRatings.Remove(rating);
                context.SaveChanges();

            }
            return rating;
        }

        public IEnumerable<BookAverageRating> GetAllAverageRating()
        {
            return context.BookAverageRatings;
        }

        public BookAverageRating GetAverageRating(int Id)
        {
            return context.BookAverageRatings.Find(Id);
        }

        public BookAverageRating Update(BookAverageRating ratingChanges)
        {
            var rating = context.BookAverageRatings.Attach(ratingChanges);
            rating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return ratingChanges;
        }
    }
}
