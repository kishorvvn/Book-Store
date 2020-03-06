using BookManagements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.ViewModels
{
    public class AddReviewViewModel
    {
        public Book Book { get; set; }
        public Review Review { get; set; }

    }
}
