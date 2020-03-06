using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
    public interface IBookAverageRatingRepository
    {
     
        IEnumerable<BookAverageRating> GetAllAverageRating();
        BookAverageRating Add(BookAverageRating bookAverageRating);
        BookAverageRating Delete(int id);
        BookAverageRating GetAverageRating(int Id);
        BookAverageRating Update(BookAverageRating ratingChanges);

    }
}
