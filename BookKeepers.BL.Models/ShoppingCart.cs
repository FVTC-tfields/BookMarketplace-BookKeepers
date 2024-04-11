using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL.Models
{
    public   class ShoppingCart
    {
        public List<Book> Items { get; set; }
        public int TotalCount { get { return Items.Count; } }

        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public double TotalCost { get; set; }
        public double Tax { get { return TotalCost * .05; } }
        public double TCt { get { return TotalCost + Tax; } }

        public ShoppingCart()
        {
            Items = new List<Book>();
        }

        public void Add(Book book)
        {
            if (!Items.Any(n => n.Id == book.Id))
            {
                Items.Add(book);
            }
            else
            {
                foreach (var item in Items.Where(n => n.Id == book.Id))
                {
                    item.Quantity++;
                }
            }

            TotalCost += book.Cost;
        }

        public void Remove(Book book)
        {
            foreach (var item in Items.Where(n => n.Id == book.Id))
            {
                TotalCost -= (item.Cost * item.Quantity);
            }
            Items.Remove(book);
        }
    }
}
