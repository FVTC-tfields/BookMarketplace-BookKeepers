using BookKeepers.BL;
using BookKeepers.BL.Models;
using Microsoft.AspNetCore.Mvc;
using BookKeepers.UI.Extensions;

namespace AuthorKeepers.UI.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of All Authors";
            return View(AuthorManager.Load());
        }

        public IActionResult Details(int id)
        {
            return View(AuthorManager.GetById(id));
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create Author";
            return View();
        }
        [HttpPost]

        public IActionResult Create(Author author)
        {
            try
            {
                int result = AuthorManager.Insert(author);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            return View(AuthorManager.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Author author, bool rollback = false)
        {
            try
            {
                int result = AuthorManager.Update(author);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(author);
            }
        }

        public IActionResult Delete(int id)
        {
            return View(AuthorManager.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, Author author, bool rollback = false)
        {
            try
            {
                int result = AuthorManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(author);
            }
        }
    }
}
