using LibraryManagement.Data.Interfaces;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class BookController:Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        public BookController(IBookRepository bookRepository,IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }
        public IActionResult List(int? AuthorId, int? borrowerId)
        {
            if (AuthorId == null && borrowerId == null) {
                var Books = _bookRepository.GetAllWithAuthor();
                if (Books.Count() == 0)
                {
                    return View("Empty");
                }
                else
                {
                    return View(Books);
                }

            }
            else if (AuthorId != null)
            {
                var author = _authorRepository.GetWithBooks((int)AuthorId);
                if (author.Books.Count() == 0)
                {
                    return View("Author Empty", author);
                }
                else
                {
                    return View(author.Books);
                }
            }
            else if (borrowerId != null)
            {
                var books = _bookRepository.FindWithAuthorAndBorrower(c => c.BorrowerId == borrowerId);
                if (books.Count() == 0)
                {
                    return View("Empty");
                }
                else
                {
                    return View(books);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public IActionResult Create()
        {
            var bookVM = new BookViewModel()
            {
                Author = _authorRepository.GetAll()
            };
            return View("bookVM");
        }
       [HttpPost]
       public IActionResult Create(BookViewModel bookViewModel)
        {
            _bookRepository.Create(bookViewModel.Book);
            return RedirectToAction("List");
        }
        public IActionResult Update(int id)
        {
            var bookVM = new BookViewModel() {
                Book = _bookRepository.GetById(id),
                Author = _authorRepository.GetAll()

            };
            return View("bookVM");

        }
        [HttpPost]
        public IActionResult Update(BookViewModel bookViewModel)
        {
            _bookRepository.Update(bookViewModel.Book);
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetById(id);
            _bookRepository.Delete(book);
            return RedirectToAction("List");
        }
    }
}
