using BookKeepers.BL;
using BookKeepers.BL.Models;
using Microsoft.AspNetCore.Mvc;
using BookKeepers.UI.Extensions;
using BookKeepers.UI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using BookKeepers.UI.ViewModels;

namespace BookKeepers.UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingCart cart;

        // GET: ShoppingCartController
        public IActionResult Index()
        {
            ViewBag.Title = "Shopping Cart";
            cart = GetShoppingCart();
            return View(cart);
        }

        private ShoppingCart GetShoppingCart()
        {
            if (HttpContext.Session.GetObject<ShoppingCart>("cart") != null)
            {
                return HttpContext.Session.GetObject<ShoppingCart>("cart");
            }
            else
            {
                return new ShoppingCart();
            }
        }

        public IActionResult Remove(int id)
        {
            cart = GetShoppingCart();
            Book book = cart.Items.FirstOrDefault(i => i.Id == id);
            ShoppingCartManager.Remove(cart, book);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add(int id)
        {
            cart = GetShoppingCart();
            Book book = BookManager.LoadById(id);
            ShoppingCartManager.Add(cart, book);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction(nameof(Index), "Movie");
        }

        public IActionResult Checkout()
        {
            if (Authenticate.IsAuthenticated(HttpContext))
            {
                cart = GetShoppingCart();
                ShoppingCartManager.Checkout(cart);
                HttpContext.Session.SetObject("cart", null);

                CustomerViewModel customerVM = new CustomerViewModel();
                customerVM.Customers = CustomerManager.Load();

                return View("AssignToCustomer", customerVM);
            }
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }

        public IActionResult FirstStop()
        {
            if (Authenticate.IsAuthenticated(HttpContext))
            {
                CustomerViewModel customerVM = new CustomerViewModel();
                customerVM.Customers = CustomerManager.Load();

                return View("AssignToCustomer", customerVM);
            }
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }

        public ActionResult AssignToCustomer()
        {
            try
            {
                // Get the user from session and store it in a variable
                User user = HttpContext.Session.GetObject<User>("user");

                // Instantiate a new instance of the CustomerVM view model
                CustomerViewModel customerVM = new CustomerViewModel();

                // Get and Put the cart into the viewmodel
                cart = GetShoppingCart();
                customerVM.Cart = cart;

                // Load ViewModel.Customers list
                customerVM.Customers = CustomerManager.Load();

                // Set the UserId in the Viewmodel
                customerVM.UserId = user.Id;

                // if the UserId has any customers, set the ViewModel.CustomerId to the first one. Could have more than one.
                if (customerVM.Customers.Any())
                {
                    customerVM.CustomerId = customerVM.Customers.First().Id;
                }

                // Put the ViewData["ReturnUrl"] to the UriHelper.GetDisplayUri(HttpContext.Request);
                ViewData["ReturnUrl"] = UriHelper.GetDisplayUrl(HttpContext.Request);

                // return the view with viewmodel as the model
                return View(customerVM);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AssignToCustomer(CustomerViewModel customerVM)
        {
            try
            {
                // Get and assign the ViewModel.Cart
                cart = customerVM.Cart;

                // Add the Order like you did in the Checkout Method
                cart = GetShoppingCart();
                ShoppingCartManager.Checkout(cart);
                // Clear the Shopping cart
                HttpContext.Session.SetObject("cart", null);
                // Show the thank you for your order screen

                return View("Checkout");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
