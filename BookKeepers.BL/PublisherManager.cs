using BookKeepers.BL.Models;
using BookKeepers.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public static class PublisherManager
    {
        public static List<Publisher> Load()
        {
            try
            {
                List<Publisher> list = new List<Publisher>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from s in dc.tblPublishers
                     select new
                     {
                         s.Id,
                         s.Name,
                     })
                     .ToList()
                    .ForEach(book => list.Add(new Publisher
                    {
                        Id = book.Id,
                        Name = book.Name,
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
