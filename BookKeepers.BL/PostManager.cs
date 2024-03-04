using BookKeepers.BL.Models;
using BookKeepers.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public static class PostManager
    {
        public static List<Post> Load()
        {
            try
            {
                List<Post> list = new List<Post>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from s in dc.tblPosts
                     select new
                     {
                         s.Id,
                         s.Description,
                     })
                     .ToList()
                    .ForEach(book => list.Add(new Post
                    {
                        Id = book.Id,
                        Description = book.Description,
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
