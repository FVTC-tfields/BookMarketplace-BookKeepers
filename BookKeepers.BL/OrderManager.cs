using BookKeepers.BL.Models;
using BookKeepers.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public static class OrderManager
    {
        public static List<Order> Load()
        {
            try
            {
                List<Order> list = new List<Order>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from s in dc.tblOrders
                     select new
                     {
                         s.Id,
                         s.OrderDate,
                         s.ShipDate,
                     })
                     .ToList()
                    .ForEach(book => list.Add(new Order
                    {
                        Id = book.Id,
                        OrderDate = book.OrderDate,
                        ShipDate = book.ShipDate,
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
