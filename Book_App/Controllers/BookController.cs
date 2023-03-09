using BookApp.Data;
using BookApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;
        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Books.ToList();
            return View(result);

        }
        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(Book model)
        {
            if (ModelState.IsValid)
            {
                var bk = new Book()
                {
                    bookName = model.bookName,
                    author = model.author,
                    price = model.price
                    
                };
                context.Books.Add(bk);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Empty Field cannot be submit";
                return View(model);
            }

        }
        public IActionResult DeleteBook(int id)
        {
            var bk = context.Books.SingleOrDefault(p => p.bookId == id);
            context.Books.Remove(bk);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult UpdateBook(int id)
        {
            var bk = context.Books.SingleOrDefault(p => p.bookId == id);
            var result = new Book()
            {
                bookId = bk.bookId,
                bookName = bk.bookName,
                author = bk.author,
                price = bk.price
                
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateBook(Book model)
        {
            var bk = new Book()
            {
                bookId = model.bookId,
               bookName = model.bookName,
                author = model.author,
                price = model.price
                
            };
            context.Books.Update(bk);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
