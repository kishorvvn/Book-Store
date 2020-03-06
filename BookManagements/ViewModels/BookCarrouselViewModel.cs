using BookManagements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.ViewModels
{
    public class BookCarrouselViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public Review Review { get; set; }
        public Category Category { get; set; }

        public IEnumerable<Review> Reviews { get; set; }
        public int AverageRating { get; set; }
        public HomeDetailsViewModel HomeDetailsViewModel { get; set; }
        public IEnumerable<HomeDetailsViewModel> HomeDetailsViewModels { get; set; }

        public BookAverageRating BookAverageRating { get; set; }
        public IEnumerable<BookAverageRating> BookAverageRatings { get; set; }



    }
}
