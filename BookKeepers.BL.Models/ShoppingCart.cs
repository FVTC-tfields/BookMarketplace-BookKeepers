using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL.Models
{
    public class ShoppingCart
    {
        public List<Book> Items { get; set; }
        public int TotalCount { get { return Items.Count; } }

        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public double TotalCost { get; set; }
        public double Tax { get { return TotalCost * .05; } }
        public double TCt { get { return TotalCost + Tax; } }

        public int Id { get; set; }

        public ShoppingCart()
        {
            Items = new List<Book>();
        }

        public void Add(Book book)
        {
            if (!Items.Any(n => n.Id == book.Id))
            {
                Items.Add(book);
                book.Quantity = 1;
            }
            else
            {
                foreach (var item in Items.Where(n => n.Id == book.Id))
                {
                    item.Quantity++;
                }
            }

            TotalCost += (Convert.ToDouble(book.Cost) * book.Quantity);
        }

        public void Remove(Book book)
        {
            var existingBook = Items.FirstOrDefault(n => n.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Quantity--;
                if (existingBook.Quantity == 0)
                {
                    Items.Remove(existingBook);
                }
                // Recalculate total cost
                TotalCost -= Convert.ToDouble(existingBook.Cost);
            }
        }

    }
}
