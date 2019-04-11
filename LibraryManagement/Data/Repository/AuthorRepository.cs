using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Repository
{
    public class AuthorRepository:Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context):base(context)
        {

        }
        public IEnumerable<Author> GetAllWithBooks()
        {
            return _context.Authors.Include(c => c.Books);
        }

        public Author GetWithBooks(int id)
        {
            return _context.Authors.Where(c => c.AuthorId == id).Include(c => c.Books).FirstOrDefault();
        }
    }
}
