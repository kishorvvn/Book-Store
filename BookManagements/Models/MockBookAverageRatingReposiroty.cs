using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
    public class MockBookAverageRatingReposiroty : IBookAverageRatingRepository
    {
        private readonly IReviewRepository reviewRepository;
        private List<BookAverageRating> _bookAverageRating;
        public MockBookAverageRatingReposiroty( IReviewRepository reviewRepository)
        {
            _bookAverageRating = new List<BookAverageRating>()
            {
                
            };
            this.reviewRepository = reviewRepository;
        }






        public BookAverageRating Add(BookAverageRating bookAverageRating)
        {
            bookAverageRating.Id = _bookAverageRating.Max(e => e.Id) + 1;

            
                var review5 = reviewRepository.GetAllReviews().Where(p => p.BookId == bookAverageRating.Book.Id).Where(p => p.Rating == 5).Count();
                var review4 = reviewRepository.GetAllReviews().Where(p => p.BookId == bookAverageRating.Book.Id).Where(p => p.Rating == 4).Count();
                var review3 = reviewRepository.GetAllReviews().Where(p => p.BookId == bookAverageRating.Book.Id).Where(p => p.Rating == 3).Count();
                var review2 = reviewRepository.GetAllReviews().Where(p => p.BookId == bookAverageRating.Book.Id).Where(p => p.Rating == 2).Count();
                var review1 = reviewRepository.GetAllReviews().Where(p => p.BookId == bookAverageRating.Book.Id).Where(p => p.Rating == 1).Count();

                double total = ((5 * review5) + (4 * review4) + (3 * review3) + (2 * review2) + (1 * review1));

                var totalReviews = (review1 + review2 + review3 + review4 + review5);

                var average = total / totalReviews;

            bookAverageRating.AverageRating = average;
            _bookAverageRating.Add(bookAverageRating);

            return bookAverageRating;
        }

        public BookAverageRating Delete(int id)
        {
            BookAverageRating bookAverageRating = _bookAverageRating.FirstOrDefault(e => e.Id == id);
            if (bookAverageRating != null)
            {
                _bookAverageRating.Remove(bookAverageRating);
            }
            return bookAverageRating;
        }

        public IEnumerable<BookAverageRating> GetAllAverageRating()
        {
            return _bookAverageRating;
        }

        public BookAverageRating GetAverageRating(int Id)
        {
            return _bookAverageRating.FirstOrDefault(e => e.Id == Id);
        }

        public BookAverageRating Update(BookAverageRating ratingChanges)
        {
            BookAverageRating book = _bookAverageRating.FirstOrDefault(e => e.Id == ratingChanges.Id);
            if (book != null)
            {
                book.AverageRating = ratingChanges.AverageRating;
                book.Book = ratingChanges.Book;
                
            }
            return book;
        }
    }
}
