using LibraryManagement.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class DbInitialize
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();
                var Likhon = new Customer {Name="Md.Likhon Mia" };
                var Alim = new Customer { Name = "Md.Abdul Alim" };
                var Emon = new Customer { Name = "Md.Emon Mia" };
                context.Customers.Add(Likhon);
                context.Customers.Add(Alim);
                context.Customers.Add(Emon);
                var authorjalal = new Author
                {
                    Name = "Jalauddin Rumi",
                    Books = new List<Book>()
                    {
                        new Book{Title="Amar poran"},
                        new Book{Title="Ami ja cai"}
                    }
                };
                var authorlikhon = new Author
                {
                    Name = "Lkhon khusbu ",
                    Books = new List<Book>()
                    {
                        new Book{Title="Amar sopno tumi"},
                        new Book{Title="Amar valobasa khusbu"}
                    }
                };
                context.Authors.Add(authorjalal);
                context.Authors.Add(authorlikhon);
                context.SaveChanges();
            }
        }
    }
}
