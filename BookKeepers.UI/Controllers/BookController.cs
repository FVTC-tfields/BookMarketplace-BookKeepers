using BookKeepers.BL;
using BookKeepers.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace TJO.DVDCentral.UI.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of All Books";
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create Book";
            return View();
        }
        [HttpPost]

        public IActionResult Create(Book book)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, Book book, bool rollback = false)
        {
            try
            {
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
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id, Book book, bool rollback = false)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(book);
            }
        }
    }
}
