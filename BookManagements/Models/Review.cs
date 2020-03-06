using BookManagements.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Comments")]
        public string ReviewComments { get; set; }
        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
        public int BookId { get; set; }


        public virtual Book Book { get; set; }
    }
}
