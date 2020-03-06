using BookManagements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.ViewModels
{
    public class HomeDetailsViewModel
    {
       
        public int CategoryId { get; set; }
        public string PageTitle { get; set; }
        public int BookAverageRatingId { get; set; }


        public int ReviewId { get; set; }
        public Review Review { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<BookAverageRating> BookAverageRatings { get; set; }


        public double AvgRating { get; set; }

        public Book Book { get; set; }
        public Category Category { get; set; }
        public BookAverageRating BookAverageRating { get; set; }



    }
}
