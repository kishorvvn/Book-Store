﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.Models
{
    public class MockBookRepository : IBookRepository
    {
        private List<Book> _bookList;
        public MockBookRepository()
        {
            _bookList = new List<Book>()
            {
                new Book() { Id = 1, Title = "Cook with me", Author = "Kishor", CategoryId = 1, ISBN = "123456789", Price = 12.59},
                new Book() { Id = 2, Title = "The inner you..", Author = "Kishor", CategoryId = 2, ISBN = "123456789", Price = 12.59}
            };
        }

        public Book Add(Book book)
        {
            book.Id = _bookList.Max(e => e.Id) + 1;
            _bookList.Add(book);
            return book;
        }

        public Book Delete(int id)
        {
            Book book = _bookList.FirstOrDefault(e => e.Id == id);
            if(book != null)
            {
                _bookList.Remove(book);
            }
            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookList;
        }

        public Book GetBook(int Id)
        {
            return _bookList.FirstOrDefault(e => e.Id == Id);
        }

        public Book Update(Book bookChanges)
        {
            Book book = _bookList.FirstOrDefault(e => e.Id == bookChanges.Id);
            if (book != null)
            {
                book.Title = bookChanges.Title;
                book.Author = bookChanges.Author;
                book.Category = bookChanges.Category;
                book.CategoryId = bookChanges.CategoryId;
                book.ISBN = bookChanges.ISBN;
                book.Price = bookChanges.Price;
                book.PhotoPath = bookChanges.PhotoPath;
            }
            return book;
        }
    }
}
