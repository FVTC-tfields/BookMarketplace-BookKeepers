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

        public static Author GetById(int id)
        {
            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    tblAuthor? row = dc.tblAuthors.Where(s => s.Id == id).FirstOrDefault();

                    if (row != null)
                    {
                        return new Author
                        {
                            Id = row.Id,
                            LastName= row.LastName,
                            FirstName = row.FirstName
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

        public static int Insert(Author author, bool rollback = false)
        {
            int result = 0;

            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback)
                        dbContextTransaction = dc.Database.BeginTransaction();

                    tblAuthor row = new tblAuthor();

                    row.Id = dc.tblAuthors.Any() ? dc.tblAuthors.Max(s => s.Id) + 1 : 1;

                    row.FirstName = author.FirstName;
                    row.LastName = author.LastName;

                    author.Id = row.Id;

                    dc.tblAuthors.Add(row);

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

                    tblAuthor row = dc.tblAuthors.FirstOrDefault(s => s.Id == id);


                    if (row != null)
                    {
                        dc.tblAuthors.Remove(row);
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

        public static int Update(Author author, bool rollback = false)
        {

            try
            {
                int results = 0;

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblAuthor row = dc.tblAuthors.FirstOrDefault(s => s.Id == author.Id);

                    if (row != null)
                    {
                        row.FirstName = author.FirstName;
                        row.LastName = author.LastName;

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
