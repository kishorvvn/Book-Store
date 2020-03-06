using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookManagements.Models;
using BookManagements.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookManagements.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IHostingEnvironment iHostingEnvironment;
        private readonly AppDbContext context;
        private readonly ICategoryRepository categoryRepository;
        private readonly IReviewRepository reviewRepository;
        private readonly IBookAverageRatingRepository bookAverageRatingRepository;

        public HomeController(IBookRepository bookRepository, 
            IHostingEnvironment iHostingEnvironment, 
            AppDbContext context,
            ICategoryRepository categoryRepository,
            IReviewRepository reviewRepository,
            IBookAverageRatingRepository bookAverageRatingRepository)
        {
            _bookRepository = bookRepository;
            this.iHostingEnvironment = iHostingEnvironment;
            this.context = context;
            this.categoryRepository = categoryRepository;
            this.reviewRepository = reviewRepository;
            this.bookAverageRatingRepository = bookAverageRatingRepository;
        }

        // GET: /<controller>/
        [AllowAnonymous]
        public ViewResult Index()
        {
            BookCarrouselViewModel model = new BookCarrouselViewModel()
            {

                Books = _bookRepository.GetAllBooks(),
                
                Reviews = reviewRepository.GetAllReviews(),
           BookAverageRatings = bookAverageRatingRepository.GetAllAverageRating()
                
            };

           

           return View(model);
        }

        [AllowAnonymous]
        public ViewResult Details(int id)
        {
            var review5 = reviewRepository.GetAllReviews().Where(p => p.BookId == id).Where(p => p.Rating == 5).Count();
            var review4 = reviewRepository.GetAllReviews().Where(p => p.BookId == id).Where(p => p.Rating == 4).Count();
            var review3 = reviewRepository.GetAllReviews().Where(p => p.BookId == id).Where(p => p.Rating == 3).Count();
            var review2 = reviewRepository.GetAllReviews().Where(p => p.BookId == id).Where(p => p.Rating == 2).Count();
            var review1 = reviewRepository.GetAllReviews().Where(p => p.BookId == id).Where(p => p.Rating == 1).Count();

            double total = ((5 * review5) + (4 * review4) + (3 * review3) + (2 * review2) + (1 * review1));
            var totalReviews = (review1 + review2 + review3 + review4 + review5);
             var average = total / totalReviews;

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Book = _bookRepository.GetBook(id),
                PageTitle = "Book Details",
                Reviews = reviewRepository.GetAllReviews(),
                AvgRating = average,
                
                
            };

            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(BookCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Book newBook = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    CategoryId = model.CategoryId,
                    Category = model.Category,
                    ISBN = model.ISBN,
                    Price = model.Price,
                    PhotoPath = uniqueFileName,
                };
                _bookRepository.Add(newBook);
                return RedirectToAction("details", new { id = newBook.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Book book = _bookRepository.GetBook(id);
            BookEditViewModel bookEditViewModel = new BookEditViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Category = book.Category,
                CategoryId = book.CategoryId,
                ISBN = book.ISBN,
                Price = book.Price,
                ExixtingPhotoPath = book.PhotoPath
            };
            return View(bookEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(BookEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Book book = _bookRepository.GetBook(model.Id);
                book.Title = model.Title;
                book.Author = model.Author;
                book.Category = model.Category;
                book.CategoryId = model.CategoryId;
                book.ISBN = model.ISBN;
                book.Price = model.Price;

                if (model.Photo != null)
                {
                    if (model.ExixtingPhotoPath != null)
                    {
                        string filePath = Path.Combine(iHostingEnvironment.WebRootPath, "images", model.ExixtingPhotoPath);
                        System.IO.File.Delete(filePath);
                    };
                    book.PhotoPath = ProcessUploadedFile(model);
                }
                _bookRepository.Update(book);
                return RedirectToAction("index");
            }
            return View();
        }

        private string ProcessUploadedFile(BookCreateViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string upoadsFolder = Path.Combine(iHostingEnvironment.WebRootPath, "images");

                var fileName = Path.GetFileName(model.Photo.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                string filePath = Path.Combine(upoadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }

     
        public ViewResult Delete(int id)
        {
            var books = _bookRepository.GetBook(id);
            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]

      
        public IActionResult DeleteConfirmed(int id)
        {
            _bookRepository.Delete(id);
            return RedirectToAction ("Index");
        }

    }
}
