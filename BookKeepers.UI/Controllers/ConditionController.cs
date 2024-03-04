using BookKeepers.BL;
using BookKeepers.BL.Models;
using Microsoft.AspNetCore.Mvc;
using BookKeepers.UI.Extensions;

namespace BookKeepers.UI.Controllers
{
    public class ConditionController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of All Conditions";
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create Condition";
            return View();
        }
        [HttpPost]

        public IActionResult Create(Condition condition)
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
        public IActionResult Edit(int id, Condition condition, bool rollback = false)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(condition);
            }
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id, Condition condition, bool rollback = false)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(condition);
            }
        }
    }
}
