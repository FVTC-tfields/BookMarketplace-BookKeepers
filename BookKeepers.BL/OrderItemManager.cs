using BookKeepers.BL.Models;
using BookKeepers.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public static class OrderItemManager
    {
        public static List<OrderItem> Load()
        {
            try
            {
                List<OrderItem> list = new List<OrderItem>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from s in dc.tblOrderItems
                     select new
                     {
                         s.Id,
                         s.Photo,
                         s.Description,
                         s.Title
                     })
                     .ToList()
                    .ForEach(book => list.Add(new OrderItem
                    {
                        Id = book.Id,
                        Photo = book.Photo,
                        Description = book.Description,
                        Title = book.Title
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
