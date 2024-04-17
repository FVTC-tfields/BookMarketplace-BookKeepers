using BookKeepers.BL.Models;

namespace BookKeepers.UI.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public List<Customer> Customers { get; set; }
        public int UserId { get; set; }
        public ShoppingCart Cart { get; set; }
    }
}
