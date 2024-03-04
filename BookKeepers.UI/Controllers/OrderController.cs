using BookKeepers.BL;
using BookKeepers.BL.Models;
using Microsoft.AspNetCore.Mvc;
using BookKeepers.UI.Extensions;

namespace BookKeepers.UI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of All Orders";
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create Order";
            return View();
        }
        [HttpPost]

        public IActionResult Create(Order order)
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
        public IActionResult Edit(int id, Order order, bool rollback = false)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(order);
            }
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id, Order order, bool rollback = false)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(order);
            }
        }
    }
}
