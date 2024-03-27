using BookKeepers.BL;
using BookKeepers.BL.Models;
using Microsoft.AspNetCore.Mvc;
using BookKeepers.UI.Extensions;

namespace BookKeepers.UI.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of All Publishers";
            return View(PublisherManager.Load());
        }

        public IActionResult Details(int id)
        {
            return View(PublisherManager.GetById(id));
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create Publisher";
            return View();
        }
        [HttpPost]

        public IActionResult Create(Publisher publisher)
        {
            try
            {
                int result = PublisherManager.Insert(publisher);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            return View(PublisherManager.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Publisher publisher, bool rollback = false)
        {
            try
            {
                int result = PublisherManager.Update(publisher);    
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(publisher);
            }
        }

        public IActionResult Delete(int id)
        {
            return View(PublisherManager.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, Publisher publisher, bool rollback = false)
        {
            try
            {
                int result = PublisherManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(publisher);
            }
        }
    }
}
