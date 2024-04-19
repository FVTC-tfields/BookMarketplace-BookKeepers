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
    public static class BookManager
    {
        public static List<Book> Load()
        {
            try
            {
                List<Book> list = new List<Book>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from b in dc.tblBooks
                     join a in dc.tblAuthors on b.AuthorId equals a.Id
                     join p in dc.tblPublishers on b.PublisherId equals p.Id
                     join s in dc.tblSubjects on b.SubjectId equals s.Id
                     select new
                     {
                         b.Id,
                         b.Title,
                         b.Year,
                         b.Photo,
                         b.ISBN,
                         b.Condition,
                         a.FirstName,
                         a.LastName,
                         p.Name,
                         SubjectName = s.Title 

                     })
                     .ToList()
                    .ForEach(book => list.Add(new Book
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Year = book.Year,
                        Photo = book.Photo,
                        ISBN = book.ISBN,
                        Condition = book.Condition,
                        AuthorName = String.Format("{0} {1}", book.FirstName, book.LastName),
                        PublisherName = book.Name,
                        SubjectName = book.SubjectName,
                    }));
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Book GetById(int id, bool allNames = false)
        {
            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    tblBook? row = dc.tblBooks.Where(s => s.Id == id).FirstOrDefault();

                    if (row != null)
                    {
                        if (allNames)
                        {
                            return new Book
                            {
                                Id = row.Id,
                                Title = row.Title,
                                PublisherName = PublisherManager.GetById(row.PublisherId).Name,
                                ISBN = row.ISBN,
                                Photo = row.Photo,
                                Year = row.Year,
                                AuthorName = AuthorManager.GetById(row.AuthorId).FullName,
                                SubjectName = SubjectManager.GetById(row.SubjectId).Title,
                                Condition = row.Condition,
                            };
                        }
                        else
                        {
                            return new Book
                            {
                                Id = row.Id,
                                Title = row.Title,
                                PublisherId = row.PublisherId,
                                ISBN = row.ISBN,
                                Photo = row.Photo,
                                Year = row.Year,
                                AuthorId = row.AuthorId,
                                SubjectId = row.SubjectId,
                                Condition = row.Condition,
                            };
                        }
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

        public static int Insert(Book book, bool rollback = false)
        {
            int result = 0;

            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback)
                        dbContextTransaction = dc.Database.BeginTransaction();

                    tblBook row = new tblBook();

                    row.Id = dc.tblBooks.Any() ? dc.tblBooks.Max(s => s.Id) + 1 : 1;
                    row.Title = book.Title;
                    row.Year = book.Year;
                    row.Photo = book.Photo;
                    row.ISBN = book.ISBN;
                    row.Condition = book.Condition;
                    row.SubjectId = book.SubjectId;
                    row.AuthorId = book.AuthorId;
                    row.PublisherId = book.PublisherId;

                    book.Id = row.Id;

                    dc.tblBooks.Add(row);
                    
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

                    tblBook row = dc.tblBooks.FirstOrDefault(s => s.Id == id);


                    if (row != null)
                    {
                        dc.tblBooks.Remove(row);
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

        public static int Update(Book book, bool rollback = false)
        {

            try
            {
                int results = 0;

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblBook row = dc.tblBooks.FirstOrDefault(s => s.Id == book.Id);

                    if (row != null)
                    {
                        row.Title = book.Title;
                        row.ISBN = book.ISBN;
                        row.Year = book.Year;
                        row.SubjectId = book.SubjectId;
                        row.PublisherId = book.PublisherId;
                        row.AuthorId = book.AuthorId;
                        row.Condition = book.Condition;
                        
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

        //public static Book LoadById(int id)
        //{
        //    try
        //    {
        //        using (BookKeepersEntities dc = new BookKeepersEntities())
        //        {
        //            tblBook entity = dc.tblBooks.FirstOrDefault(m => m.Id == id);

        //            if (entity != null)
        //            {
        //                return new Book
        //                {
        //                    Id = entity.Id,
        //                    Title = entity.Title,
        //                    Description = entity.Description,
        //                    AuthorId = entity.AuthorId,
        //                    PublisherId = entity.PublisherId,
        //                    SubjectId = entity.SubjectId,
        //                    Year = entity.Year,
        //                    Photo = entity.Photo,
        //                    ISBN = entity.ISBN,
        //                    Condition = entity.Condition,
        //                    Cost = (float)entity.Cost,
        //                };
        //            }
        //            else
        //            {
        //                throw new Exception();
        //            }
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
