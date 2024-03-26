using BookKeepers.BL.Models;
using BookKeepers.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public static class SubjectManager
    {
        public static List<Subject> Load()
        {
            try
            {
                List<Subject> list = new List<Subject>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from s in dc.tblSubjects
                     select new
                     {
                         s.Id,
                         s.Title,
                     })
                     .ToList()
                    .ForEach(book => list.Add(new Subject
                    {
                        Id = book.Id,
                        Title = book.Title,
                    }));
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Subject GetById(int id)
        {
            try
            {


                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    tblSubject? row = dc.tblSubjects.Where(s => s.Id == id).FirstOrDefault();

                    if (row != null)
                    {
                        return new Subject
                        {
                            Id = row.Id,
                            Title = row.Title,
                        };

                    }
                    else
                    {
                        throw new Exception("Row does not exist.");
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
