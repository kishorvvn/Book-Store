using BookManagements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.ViewModels
{
    public class IndexViewModel
    {
        
        public IEnumerable<Book> Books { get; set; }
        public string CategoryName { get; set; }
       

    }
}
