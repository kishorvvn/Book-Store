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
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly ICategoryRepository categoryRepository;
       

        public BookController(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            this.bookRepository = bookRepository;
            this.categoryRepository = categoryRepository;
        }
        IEnumerable<Book> books;
       
        // GET: /<controller>/
        public ViewResult List(int id)
        {

            string categoryName = string.Empty;
                books = bookRepository.GetAllBooks().OrderBy(n => n.Id);
              if(books == null)
                {
                    ViewBag.Title = $"No books available in this category";
                    return View("NotFound");
                } 
              else
            {
                books = bookRepository.GetAllBooks()
                       .Where(p => p.Category.Id == id)
                       .OrderBy(p => p.Category.CategoryName);
                categoryName = categoryRepository.GetCategory(id).CategoryName;

            }
            var indexViewModel = new IndexViewModel
            {
                Books = books,
                CategoryName = categoryName,
               
            };
            return View(indexViewModel);
        }
    }
}
