using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context):base(context)
        {

        }
        public IEnumerable<Book> FindWithAuthor(Func<Book, bool> Predicate)
        {
            return _context.Books.Include(c => c.Author).Where(Predicate);
        }

        public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> Predicate)
        {
            return _context.Books
                .Include(c => c.Author)
                .Include(c=>c.Borrower)
                .Where(Predicate);

        }

        public IEnumerable<Book> GetAllWithAuthor()
        {
            return _context.Books.Include(c => c.Author);
        }
    }
}
