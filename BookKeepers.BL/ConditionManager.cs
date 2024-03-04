using BookKeepers.BL.Models;
using BookKeepers.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public static class ConditionManager
    {
        public static List<Condition> Load()
        {
            try
            {
                List<Condition> list = new List<Condition>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from s in dc.tblConditions
                     select new
                     {
                         s.Id,
                         s.Description,
                     })
                     .ToList()
                    .ForEach(book => list.Add(new Condition
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
