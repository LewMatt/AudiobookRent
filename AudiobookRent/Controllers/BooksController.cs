using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AudiobookRent.Models;

namespace AudiobookRent.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }


        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            PopulateAuthorsDropDownList();
            PopulateCategoriesDropDownList();
            PopulatePublishersDropDownList();
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,Title,Description,AuthorID,CategoryID,ReleaseDate,PublisherID")] Books books)
        {
            
            if (ModelState.IsValid)
            {
                db.Books.Add(books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAuthorsDropDownList(books.AuthorID);
            PopulateCategoriesDropDownList(books.CategoryID);
            PopulatePublishersDropDownList(books.PublisherID);
            return View(books);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,Title,Description,AuthorID,CategoryID,ReleaseDate,PublisherID")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Books books = db.Books.Find(id);
            db.Books.Remove(books);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void PopulateAuthorsDropDownList(object selectAuthor = null)
        {
            var AuthorQuery = from d in db.Authors
                            orderby d.LastName
                            select d;
            ViewBag.AuthorID = new SelectList(AuthorQuery, "AuthorID", null, selectAuthor);
        }
        private void PopulatePublishersDropDownList(object selectPublisher = null)
        {
            var PublisherQuery = from d in db.Publishers
                              orderby d.Name
                              select d;
            ViewBag.PublisherID = new SelectList(PublisherQuery, "PublisherID", "Name", selectPublisher);
        }
        private void PopulateCategoriesDropDownList(object selectCategory = null)
        {
            var CategoryQuery = from d in db.Categories
                              orderby d.Name
                              select d;
            ViewBag.CategoryID = new SelectList(CategoryQuery, "CategoryID", "Name", selectCategory);
        }
    }
}
