using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
    public class SqlBookRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public SqlBookRepository(AppDbContext context)
        {
            this.context = context;
        }



        public Book Add(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return book;
        }

        public Book Delete(int id)
        {
            Book book = context.Books.Find(id);
            if(book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
                
            }
            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books.Include(a => a.Category).Include(b => b.BookAverageRating);
        }

        public Book GetBook(int Id)
        {
           return context.Books.Include(b => b.BookAverageRating).FirstOrDefault(f => f.Id == Id);
            /*context.Books.Include(e => e.Category).FirstOrDefault(f => f.Id == Id);*/
        }

        public Book Update(Book bookChanges)
        {
            var book = context.Books.Attach(bookChanges);
            book.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return bookChanges;
        }
    }
}
