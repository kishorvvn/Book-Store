using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagements.Models;
using BookManagements.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookManagements.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository reviewRepository;
        private readonly AppDbContext context;
        private readonly IBookRepository bookRepository;
        private readonly IBookAverageRatingRepository bookAverageRatingRepository;

        public ReviewController(IReviewRepository reviewRepository, AppDbContext context, 
                                IBookRepository bookRepository, IBookAverageRatingRepository bookAverageRatingRepository)
        {
            this.reviewRepository = reviewRepository;
            this.context = context;
            this.bookRepository = bookRepository;
            this.bookAverageRatingRepository = bookAverageRatingRepository;
        }

        // GET: /<controller>/
        public IActionResult List(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Book = bookRepository.GetBook(id),
                PageTitle = "Book Details",
                Reviews = reviewRepository.GetAllReviews(),
            };
            
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            var book = bookRepository.GetBook(id);
            /*int Id = book.BookAverageRating.Id;*/
            return View();
        }
        [HttpPost]
        public IActionResult Add(int id, HomeDetailsViewModel model)
        {
            var book = bookRepository.GetBook(id);
            if (ModelState.IsValid)
            {

                Review newReview = new Review
                {
                    BookId = book.Id,
                    ReviewComments = model.Review.ReviewComments,
                    Rating = model.Review.Rating,
                    Book = model.Book,
                    Id = model.ReviewId,
                   
                };


               reviewRepository.Add(newReview);
              

                reviewRepository.GetAllReviews().Where(a => a.BookId == book.Id).ToList();

                var book5 = bookRepository.GetBook(id).Reviews.Where(p => p.Rating == 5).Count();
                var book4 = bookRepository.GetBook(id).Reviews.Where(p => p.Rating == 4).Count();
                var book3 = bookRepository.GetBook(id).Reviews.Where(p => p.Rating == 3).Count();
                var book2 = bookRepository.GetBook(id).Reviews.Where(p => p.Rating == 2).Count();
                var book1 = bookRepository.GetBook(id).Reviews.Where(p => p.Rating == 1).Count();


                float total = ((book1 * 1) + (book2 * 2) + (book3 * 3) + (book4 * 4) + (book5 * 5));
                var totalReviews = bookRepository.GetBook(id).Reviews.Count();
                float average = total / totalReviews;

                BookAverageRating AvgRating = new BookAverageRating
                {
                    AverageRating = average,
                    BookId = book.Id
                };

                var avgRating = bookAverageRatingRepository.GetAllAverageRating().Where(a => a.BookId == id).Count();
                /*BookAverageRating newAvgRating = new BookAverageRating
                {
                    Id = book.BookAverageRating.Id
                };*/

                if (avgRating == 0)
                {
                    
                    bookAverageRatingRepository.Add(AvgRating);
                }
                else
                {
                    bookAverageRatingRepository.Delete(AvgRating.Id);
                    bookAverageRatingRepository.Add(AvgRating);
                }
                return RedirectToAction("List", new { id = newReview.BookId });
            }
            return View();
        }


        public ViewResult Details(int id)
        {
            var book5 = bookRepository.GetBook(id).Reviews.Where(p => p.Rating == 5).Count();
            var book4 = bookRepository.GetBook(id).Reviews.Where(p => p.Rating == 4).Count();
            var book3 = bookRepository.GetBook(id).Reviews.Where(p => p.Rating == 3).Count();
            var book2 = bookRepository.GetBook(id).Reviews.Where(p => p.Rating == 2).Count();
            var book1 = bookRepository.GetBook(id).Reviews.Where(p => p.Rating == 1).Count();


            var total = (book1 + book2 + book3 + book4 + book5); 
            var totalReviews = bookRepository.GetBook(id).Reviews.Count();
            var average = total / totalReviews;

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Book = bookRepository.GetBook(id),
                PageTitle = "Book Details",
                Reviews = reviewRepository.GetAllReviews(),
                AvgRating = average
            };

            return View(homeDetailsViewModel);
        }


        public ActionResult Calculate()
        {
           
            var grandTotal = reviewRepository.GetAllReviews();
            var total = ((grandTotal.Count(p => p.Rating == 5) * 5) +
                (grandTotal.Count(p => p.Rating == 4) * 4) +
                (grandTotal.Count(p => p.Rating == 3) * 3) +
                (grandTotal.Count(p => p.Rating == 2) * 2) +
                (grandTotal.Count(p => p.Rating == 1) * 1));
            var totalReviews = grandTotal.Count();
            var average = total / totalReviews;

            var model = new HomeDetailsViewModel
            { AvgRating = average,
                };

            return View(model);
        }
    }
}
