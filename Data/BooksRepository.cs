using System.Collections.Generic;
using Fisher.Bookstore.Data;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Services
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookstoreContext db;

        public BooksRepository(BookstoreContext db)
        {
            this.db = db;
        }

        public int AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return book.Id;
        }

        public void DeleteBook(int bookId)
        {
           var book = db.Books.Find(bookId);
           db.Books.Remove(book);
           db.SaveChanges();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public Book GetBook(int bookId)
        {
            return db.Books.Find(bookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return db.Books;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void UpdateBook(Book book)
        {
            var updateBook = db.Books.Find(book.Id);
            updateBook.Title = book.Title;
            db.Books.Update(updateBook);
            db.SaveChanges();
        }

        bool IBooksRepository.BookExists(int bookId)
        {
            return (db.Books.Find(bookId) != null);
        }
    }





}