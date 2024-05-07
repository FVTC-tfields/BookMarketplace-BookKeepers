using BookKeepers.BL.Models;
using BookKeepers.PL;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public class OrderManager
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

        public static int Insert(Order order, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblOrder newRow = new tblOrder();

                    newRow.Id = dc.tblOrders.Any() ? dc.tblOrders.Max(r => r.Id) + 1 : 1;
                    newRow.CustomerId = order.CustomerId;
                    newRow.OrderDate = DateTime.Now;
                    newRow.UserId = order.UserId;
                    newRow.ShipDate = newRow.OrderDate.AddDays(3);

                    // save order items
                    foreach (OrderItem item in order.OrderItems)
                    {
                        item.OrderId = newRow.Id;
                        results += OrderItemManager.Insert(item, rollback);
                    }

                    order.Id = newRow.Id;
                    dc.tblOrders.Add(newRow);
                    results += dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
