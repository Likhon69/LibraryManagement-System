using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class CustomerController:Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;
        public CustomerController(ICustomerRepository customerRepository,IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }
        [Route("Customer")]
        public IActionResult List()
        {
            var CustomerVM = new List<CustomerViewModel>();
            var Customers = _customerRepository.GetAll();
            if (Customers.Count() == 0)
            {
                return View("Empty");
            }
            foreach(var Customer in Customers)
            {
                CustomerVM.Add(new CustomerViewModel
                {
                    Customer=Customer,
                    BookCount = _bookRepository.Count(c=>c.BorrowerId == Customer.CustomerId)
                });
            }
            return View(CustomerVM);
        }
        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);
            _customerRepository.Delete(customer);
            return RedirectToAction("List");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _customerRepository.Create(customer);
            return RedirectToAction("List");
        }
        public IActionResult Update(int id)
        {
            var customer = _customerRepository.GetById(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            _customerRepository.Update(customer);
           
            return RedirectToAction("List");
        }
    }
}
