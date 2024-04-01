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

        public static Comment GetById(int id)
        {
            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    tblComment? row = dc.tblComments.Where(s => s.Id == id).FirstOrDefault();

                    if (row != null)
                    {
                        return new Comment
                        {
                            Id = row.Id,
                            Description = row.Description,
                            Condition = row.Condition,
                            CreationDate = row.CreationDate
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

        public static int Insert(Comment comment, bool rollback = false)
        {
            int result = 0;

            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback)
                        dbContextTransaction = dc.Database.BeginTransaction();

                    tblComment row = new tblComment();

                    row.Id = dc.tblComments.Any() ? dc.tblComments.Max(s => s.Id) + 1 : 1;
                    row.Description = comment.Description;
                    row.Condition = comment.Condition;
                    row.CreationDate = comment.CreationDate;

                    comment.Id = row.Id;

                    dc.tblComments.Add(row);

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

                    tblComment row = dc.tblComments.FirstOrDefault(s => s.Id == id);


                    if (row != null)
                    {
                        dc.tblComments.Remove(row);
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

        public static int Update(Comment comment, bool rollback = false)
        {

            try
            {
                int results = 0;

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblComment row = dc.tblComments.FirstOrDefault(s => s.Id == comment.Id);

                    if (row != null)
                    {
                        row.Description = comment.Description;
                        row.Condition = comment.Condition;
                        row.CreationDate = comment.CreationDate;

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
