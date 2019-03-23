using aspnetmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvc.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Home()
        {
            // Get count of books
            BooksContext ctx = new BooksContext();
            ViewBag.Count = ctx.Books.Count();
            return View();
        }

        public ActionResult List()
        {
            // Get count of books
            BooksContext ctx = new BooksContext();
            return View(ctx.Books.OrderBy(b => b.Price).ToList<Book>());
        }

        [HttpGet]
        public ActionResult Add()
        {
            Book b = new Book();
            return View(b);
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                BooksContext ctx = new BooksContext();
                ctx.Books.Add(book);
                ctx.SaveChanges();
                ViewBag.Message = "Book has been added successfully!";
                book.Title = "";
                book.Author = "";
                book.Price = 0;
                ModelState.Clear();
            }
            else
            {
                Console.WriteLine("Validation Failed");
            }
            return View(book);
        }
    }
}
