using LibraryManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly LibraryDbContext _context;
        public Repository(LibraryDbContext context)
        {
            _context = context;
        }
        protected void save() => _context.SaveChanges();

        public int Count(Func<T, bool> Predicate)
        {
            return _context.Set<T>().Where(Predicate).Count();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            save();
        }

        public IEnumerable<T> Find(Func<T, bool> Predicate)
        {
            return _context.Set<T>().Where(Predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            save();
        }
    }
}
