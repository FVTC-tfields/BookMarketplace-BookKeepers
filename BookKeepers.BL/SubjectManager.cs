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

        public static int Insert(Subject subject, bool rollback = false)
        {
            int result = 0;

            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback)
                        dbContextTransaction = dc.Database.BeginTransaction();

                    tblSubject row = new tblSubject();

                    row.Id = dc.tblSubjects.Any() ? dc.tblSubjects.Max(s => s.Id) + 1 : 1;

                    row.Title = subject.Title;

                    subject.Id = row.Id;

                    dc.tblSubjects.Add(row);

                    result = dc.SaveChanges();

                    if (rollback)
                        dbContextTransaction.Rollback();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblSubject row = dc.tblSubjects.FirstOrDefault(s => s.Id == id);


                    if (row != null)
                    {
                        dc.tblSubjects.Remove(row);
                        results = dc.SaveChanges();

                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row does not exist.");
                    }
                }

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(Subject subject, bool rollback = false)
        {

            try
            {
                int results = 0;

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblSubject row = dc.tblSubjects.FirstOrDefault(s => s.Id == subject.Id);

                    if (row != null)
                    {
                        row.Title = subject.Title;

                        results = dc.SaveChanges();

                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row does not exist.");
                    }

                }

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
