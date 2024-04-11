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

        public static int Insert(OrderItem orderItem, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblOrderItem row = new tblOrderItem();

                    row.Id = dc.tblOrderItems.Any() ? dc.tblOrderItems.Max(oi => oi.Id) + 1 : 1;
                    row.OrderId = orderItem.OrderId;
                    row.BookId = orderItem.BookId;
                    row.Quantity = orderItem.Quantity;
                    row.Cost = orderItem.Cost;

                    orderItem.Id = row.Id;

                    dc.tblOrderItems.Add(row);

                    results = dc.SaveChanges();

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
