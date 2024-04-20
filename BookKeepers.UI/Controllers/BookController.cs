using BookKeepers.BL;
using BookKeepers.BL.Models;
using BookKeepers.UI.Models;
using BookKeepers.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;

namespace TJO.DVDCentral.UI.Controllers
{
    public class BookController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IWebHostEnvironment webHostEnvironment) { 
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "List of All Books";
            return View(BookManager.Load());
        }

        public IActionResult Details(int id)
        {
            Book book = BookManager.GetById(id, true);
            return View(book);
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create Book";
            LoadSelectValueList();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(BookModel bookModel)
        {
            try
            {
                //Upload image to the server
                if (bookModel.CoverPhoto != null) {
                    string folder = "img/";
                    folder += bookModel.CoverPhoto.FileName;
                    bookModel.CoverPhotoUrl = bookModel.CoverPhoto.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await bookModel.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                //Create a new Book object

                Book book = new Book()
                {
                    Title = bookModel.Title,
                    Year    = bookModel.Year,
                    Photo   = bookModel.CoverPhotoUrl,
                    ISBN = bookModel.ISBN,
                    Condition = bookModel.Condition,
                    SubjectId   = bookModel.SubjectId,
                    AuthorId    = bookModel.AuthorId,
                    PublisherId = bookModel.PublisherId,
                    Cost = bookModel.Cost,
                };

                int result = BookManager.Insert(book);
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            Book book = BookManager.GetById(id);
            LoadSelectValueList();
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(int id, Book book, bool rollback = false)
        {
            try
            {
                int result = BookManager.Update(book);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(book);
            }
        }

        public IActionResult Delete(int id)
        {
            return View(BookManager.GetById(id, true));
        }

        [HttpPost]
        public IActionResult Delete(int id, Book book)
        {
            try
            {
                BookManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(book);
            }
        }

        [NonAction]
        private void LoadSelectValueList()
        {
            var authors = AuthorManager.Load();
            ViewBag.Authors = new SelectList(authors, "Id", "FullName");
            var publishers = PublisherManager.Load();
            ViewBag.Publishers = new SelectList(publishers, "Id", "Name");
            var subjects = SubjectManager.Load();
            ViewBag.subjects = new SelectList(subjects, "Id", "Title");
        }

        
    }
}
