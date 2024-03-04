using BookKeepers.BL.Models;
using BookKeepers.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public static class BookManager
    {
        public static List<Book> Load()
        {
            try
            {
                List<Book> list = new List<Book>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from s in dc.tblBooks
                     select new
                     {
                         s.Id,
                         s.Title,
                         s.Year,
                         s.Photo,
                         s.ISBN,
                     })
                     .ToList()
                    .ForEach(book => list.Add(new Book
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Year = book.Year,
                        Photo = book.Photo,
                        ISBN = book.ISBN
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
