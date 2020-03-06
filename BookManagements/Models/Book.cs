using BookManagements.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        /*public string Description { get; set; }
        [Required]
        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }
        */
        [Required]
        public double Price { get; set; }
        [Required]
        public string ISBN { get; set; }
        public string PhotoPath { get; set; }

        public int CategoryId { get; set; }
      

        public virtual BookAverageRating BookAverageRating { get; set; }


        public List<Review> Reviews { get; set; }
        public virtual Category Category { get; set; }
        







    }
}
