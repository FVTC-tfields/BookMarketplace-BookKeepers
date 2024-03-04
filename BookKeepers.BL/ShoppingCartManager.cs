using BookKeepers.BL.Models;
using BookKeepers.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public static class ShoppingCartManager
    {
        public static List<ShoppingCart> Load()
        {
            try
            {
                List<ShoppingCart> list = new List<ShoppingCart>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from s in dc.tblShoppingCarts
                     select new
                     {
                         s.Id,
                     })
                     .ToList()
                    .ForEach(book => list.Add(new ShoppingCart
                    {
                        Id = book.Id,
                    }));
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
