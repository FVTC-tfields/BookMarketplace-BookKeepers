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
                         s.UserId,
                         s.BookId,
                         s.ConditionId,
                         s.Description,
                         s.Price
                     })
                     .ToList()
                    .ForEach(book => list.Add(new Post
                    {
                        Id = book.Id,
                        UserId = book.UserId,
                        BookId = book.BookId,
                        ConditionId = book.ConditionId,
                        Description = book.Description,
                        Price = book.Price

                    }));
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Post GetById(int id)
        {
            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    tblPost? row = dc.tblPosts.Where(s => s.Id == id).FirstOrDefault();

                    if (row != null)
                    {
                        return new Post
                        {
                            Id = row.Id,
                            UserId = row.UserId,
                            BookId = row.BookId,
                            ConditionId = row.ConditionId,
                            Description = row.Description,
                            Price = row.Price
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

        public static int Insert(Post post, bool rollback = false)
        {
            int result = 0;

            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback)
                        dbContextTransaction = dc.Database.BeginTransaction();

                    tblPost row = new tblPost();

                    row.Id = dc.tblPosts.Any() ? dc.tblPosts.Max(s => s.Id) + 1 : 1;
                    row.UserId = post.UserId;
                    row.BookId = post.BookId;
                    row.ConditionId = post.ConditionId;
                    row.Description = post.Description;
                    row.Price = post.Price;

                    post.Id = row.Id;

                    dc.tblPosts.Add(row);

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

                    tblPost row = dc.tblPosts.FirstOrDefault(s => s.Id == id);


                    if (row != null)
                    {
                        dc.tblPosts.Remove(row);
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

        public static int Update(Post post, bool rollback = false)
        {

            try
            {
                int results = 0;

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblPost row = dc.tblPosts.FirstOrDefault(s => s.Id == post.Id);

                    if (row != null)
                    {
                        row.UserId = post.UserId;
                        row.BookId = post.BookId;
                        row.ConditionId = post.ConditionId;
                        row.Description = post.Description;
                        row.Price = post.Price;

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
