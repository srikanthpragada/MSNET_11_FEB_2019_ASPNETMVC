using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using aspnetmvc.Models;

namespace aspnetmvc.Controllers
{
    public class ApiBooksController : ApiController
    {
        private BooksContext db = new BooksContext();

        // GET: api/ApiBooks
        [HttpGet]
        public IQueryable<Book> GetBooks()
        {
            return db.Books;
        }

        // GET: api/ApiBooks/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();  // 404
            }

            return Ok(book);  // 200 
        }

        // PUT: api/ApiBooks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            book.Id = id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Change status of book object to modified so that 
            // UPDATE command is created for book object 
            
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApiBooks
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 
            }

            db.Books.Add(book);
            db.SaveChanges();

            return Ok(book);   // 200 
        }

        // DELETE: api/ApiBooks/5
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}