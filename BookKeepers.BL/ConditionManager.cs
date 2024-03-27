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


        public static Condition GetById(int id)
        {
            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    tblCondition? row = dc.tblConditions.Where(s => s.Id == id).FirstOrDefault();

                    if (row != null)
                    {
                        return new Condition
                        {
                            Id = row.Id,
                            Description = row.Description,
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

        public static int Insert(Condition condition, bool rollback = false)
        {
            int result = 0;

            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback)
                        dbContextTransaction = dc.Database.BeginTransaction();

                    tblCondition row = new tblCondition();

                    row.Id = dc.tblConditions.Any() ? dc.tblConditions.Max(s => s.Id) + 1 : 1;
                    row.Description = condition.Description;

                    condition.Id = row.Id;

                    dc.tblConditions.Add(row);

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

                    tblCondition row = dc.tblConditions.FirstOrDefault(s => s.Id == id);


                    if (row != null)
                    {
                        dc.tblConditions.Remove(row);
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

        public static int Update(Condition condition, bool rollback = false)
        {

            try
            {
                int results = 0;

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblCondition row = dc.tblConditions.FirstOrDefault(s => s.Id == condition.Id);

                    if (row != null)
                    {
                        row.Description = condition.Description;

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
