using BookManagements.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.ViewModels
{
    public class BookCreateViewModel
    {
       
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string ISBN { get; set; }
       /* public string Description { get; set; }
        [Required]
        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }
        */
        public Category Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public IFormFile Photo { get; set; }
    }
}
