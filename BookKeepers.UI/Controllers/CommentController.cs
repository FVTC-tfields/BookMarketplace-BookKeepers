using BookKeepers.BL;
using BookKeepers.BL.Models;
using Microsoft.AspNetCore.Mvc;
using BookKeepers.UI.Extensions;

namespace BookKeepers.UI.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of All Comments";
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create Comment";
            return View();
        }
        [HttpPost]

        public IActionResult Create(Comment comment)
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
        public IActionResult Edit(int id, Comment comment, bool rollback = false)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(comment);
            }
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id, Comment comment, bool rollback = false)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(comment);
            }
        }
    }
}
