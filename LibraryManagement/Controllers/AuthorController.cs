﻿using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class AuthorController:Controller
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository )
        {
            _authorRepository = authorRepository;
        }
        [Route("Author")]
        public IActionResult List()
        {
            var Authors = _authorRepository.GetAllWithBooks();
            if (Authors.Count() == 0)
            {
                return View("Empty");
            }
            return View(Authors);
        }
        public IActionResult Update(int id)
        {
            var Authors = _authorRepository.GetById(id);
            if (Authors == null) return NotFound();
            return View(Authors);
        }
        [HttpPost]
        public IActionResult Update(Author author)
        {
            _authorRepository.Update(author);
            return RedirectToAction("List");
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create(Author author)
        {
            _authorRepository.Create(author);
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            var author = _authorRepository.GetById(id);
            _authorRepository.Delete(author);
            return RedirectToAction("List");
        }
    }
}
