using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
    public class BookAverageRating
    {
        public int Id { get; set; }
        public double AverageRating { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

    }
}
