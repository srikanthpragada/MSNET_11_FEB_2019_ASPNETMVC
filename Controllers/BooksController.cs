﻿using aspnetmvc.Models;
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


        [OutputCache(Duration=180)]
        public ActionResult List()
        {
            /*
            var books = HttpContext.Cache["books"];
            if (books == null)
            {
                // get data into books 
                HttpContext.Cache.Insert("books", books, null,
                                          DateTime.Now.AddSeconds(120),TimeSpan.Zero);
            }
            // use books 
            */

            // Get count of books
            BooksContext ctx = new BooksContext();
            ViewBag.Timestamp = DateTime.Now.ToLongTimeString(); 
            return View(ctx.Books.OrderByDescending(b => b.Id).Take(5).ToList<Book>());
        }

        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            Book b = new Book();
            return View(b);
        }

        [HttpPost]
        [Authorize]
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

        public ActionResult Delete(int id)
        {
            // delete book with the given id 
            BooksContext ctx = new BooksContext();
            var book = ctx.Books.Find(id);
            if (book != null)
            {
                try
                {
                    ctx.Books.Remove(book);
                    ctx.SaveChanges();
                    return RedirectToAction("List");
                }
                catch(Exception ex)
                {
                    ViewBag.Message = "Sorry! Could not delete book due to error!";
                }
            }
            else
            {
                ViewBag.Message = "Sorry! Book was not found!";
            }
           

            return View();  // show view with error message 

        }

        // Display details of book
        [HttpGet]
        public ActionResult Edit(int id)
        {
            // Look for book with the given id
            BooksContext ctx = new BooksContext();
            var book = ctx.Books.Find(id);
            if (book == null)
            {
                ViewBag.Message = "Sorry! Book was not found!";
            }
            return View(book);  // show view with error message 
        }

        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            // Look for book with the given id
            BooksContext ctx = new BooksContext();
            var dbbook = ctx.Books.Find(id);
            if (dbbook == null)
            {
                ViewBag.Message = "Sorry! Book was not found!";
            }
            else
            {
                dbbook.Title = book.Title;
                dbbook.Author = book.Author;
                dbbook.Price = book.Price;
                try
                {
                    ctx.SaveChanges();
                    ViewBag.Message = "Update Book Successfully!";
                }
                catch(Exception ex)
                {
                    ViewBag.Message = "Sorry! Could not update book due to error! Try again!";
                }
            }

            return View(book);  // show view with error message 
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string title)
        {
            BooksContext ctx = new BooksContext();
            var books = from b in ctx.Books
                        where b.Title.Contains(title)
                        select b;

            return PartialView("SearchResults", books);
        }
    }
}
