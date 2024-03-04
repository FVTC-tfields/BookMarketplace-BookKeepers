using BookKeepers.BL.Models;
using BookKeepers.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public static class CommentManager
    {
        public static List<Comment> Load()
        {
            try
            {
                List<Comment> list = new List<Comment>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from s in dc.tblComments
                     select new
                     {
                         s.Id,
                         s.Description,
                         s.Condition,
                         s.CreationDate,
                     })
                     .ToList()
                    .ForEach(book => list.Add(new Comment
                    {
                        Id = book.Id,
                        Description = book.Description,
                        Condition = book.Condition,
                        CreationDate = book.CreationDate,
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
