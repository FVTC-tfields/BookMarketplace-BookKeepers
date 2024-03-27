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
    public static class PublisherManager
    {
        public static List<Publisher> Load()
        {
            try
            {
                List<Publisher> list = new List<Publisher>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from s in dc.tblPublishers
                     select new
                     {
                         s.Id,
                         s.Name,
                     })
                     .ToList()
                    .ForEach(book => list.Add(new Publisher
                    {
                        Id = book.Id,
                        Name = book.Name,
                    }));
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Publisher GetById(int id) 
        {
            try
            {


                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    tblPublisher? row = dc.tblPublishers.Where(s => s.Id == id).FirstOrDefault();

                    if (row != null)
                    {
                        return new Publisher
                        {
                            Id = row.Id,
                            Name = row.Name,
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

        public static int Insert(Publisher publisher, bool rollback = false)
        {
            int result = 0;

            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback)
                        dbContextTransaction = dc.Database.BeginTransaction();

                    tblPublisher row = new tblPublisher();

                    row.Id = dc.tblPublishers.Any() ? dc.tblPublishers.Max(s => s.Id) + 1 : 1;

                    row.Name = publisher.Name;

                    publisher.Id = row.Id;

                    dc.tblPublishers.Add(row);

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

                    tblPublisher row = dc.tblPublishers.FirstOrDefault(s => s.Id == id);


                    if (row != null)
                    {
                        dc.tblPublishers.Remove(row);
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

        public static int Update(Publisher publisher, bool rollback = false)
        {

            try
            {
                int results = 0;

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblPublisher row = dc.tblPublishers.FirstOrDefault(s => s.Id == publisher.Id);

                    if (row != null)
                    {
                      row.Name = publisher.Name;

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
