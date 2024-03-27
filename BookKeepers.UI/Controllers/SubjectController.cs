using BookKeepers.BL;
using BookKeepers.BL.Models;
using Microsoft.AspNetCore.Mvc;
using BookKeepers.UI.Extensions;

namespace BookKeepers.UI.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of All Subjects";
            return View(SubjectManager.Load());
        }

        public IActionResult Details(int id)
        {
            return View(SubjectManager.GetById(id));
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create Subject";
            return View();
        }
        [HttpPost]

        public IActionResult Create(Subject subject)
        {
            try
            {
                int result = SubjectManager.Insert(subject);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            return View(SubjectManager.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Subject subject, bool rollback = false)
        {
            try
            {
                int result = SubjectManager.Update(subject);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(subject);
            }
        }

        public IActionResult Delete(int id)
        {
            return View(SubjectManager.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, Subject subject, bool rollback = false)
        {
            try
            {
                int result = SubjectManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(subject);
            }
        }
    }
}
