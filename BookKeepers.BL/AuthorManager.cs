using BookKeepers.BL.Models;
using BookKeepers.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public static class AuthorManager
    {
        public static List<Author> Load()
        {
            try
            {
                List<Author> list = new List<Author>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from s in dc.tblAuthors
                     select new
                     {
                         s.Id,
                         s.FirstName,
                         s.LastName
                     })
                     .ToList()
                    .ForEach(author => list.Add(new Author
                    {
                        Id = author.Id,
                        FirstName = author.FirstName,
                        LastName = author.LastName
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
