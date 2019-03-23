using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace aspnetmvc.Models
{
    public class BooksContext : DbContext
    {
        public BooksContext()
            : base("name=msdbConnectionString")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
    }
}