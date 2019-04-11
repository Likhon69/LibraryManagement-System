using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public Customer Borrower { get; set; }
        public int BorrowerId { get; set; }
        public Author Author { get; set; }
        public int AuthoerId { get; set; }
        public string Title { get; internal set; }
    }
}
