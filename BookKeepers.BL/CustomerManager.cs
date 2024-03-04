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
    public static class CustomerManager
    {

        public static int Insert(Customer customer, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblCustomer entity = new tblCustomer();


                    entity.Id = customer.Id;
                    entity.UserId = customer.UserId;
                    entity.Address = customer.Address;
                    entity.City = customer.City;
                    entity.State = customer.State;
                    entity.ZIP = customer.ZIP;
                    entity.Phone = customer.Phone;


                    // IMPORTANT - BACK FILL THE ID
                    customer.Id = entity.Id;

                    dc.tblCustomers.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Update(Customer customer, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblCustomer entity = dc.tblCustomers.FirstOrDefault(s => s.Id == customer.Id);

                    if (entity != null)
                    {
                        entity.UserId = customer.UserId;
                        entity.Address = customer.Address;
                        entity.City = customer.City;
                        entity.State = customer.State;
                        entity.ZIP = customer.ZIP;
                        entity.Phone = customer.Phone;
                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblCustomer entity = dc.tblCustomers.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        dc.tblCustomers.Remove(entity);
                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Customer LoadById(int id)
        {
            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    tblCustomer entity = dc.tblCustomers.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        return new Customer
                        {
                            Id = entity.Id,
                            UserId = entity.UserId,
                            Address = entity.Address,
                            City = entity.City,
                            State = entity.State,
                            ZIP = entity.ZIP,
                            Phone = entity.Phone

                        };
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Customer? LoadByUserId(int userId)
        {
            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    tblCustomer? entity = dc.tblCustomers.FirstOrDefault(s => s.UserId == userId);

                    if (entity != null)
                    {
                        return new Customer
                        {
                            Id = entity.Id,
                            UserId = entity.UserId,
                            Address = entity.Address,
                            City = entity.City,
                            State = entity.State,
                            ZIP = entity.ZIP,
                            Phone = entity.Phone
                        };
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Customer> Load()
        {
            try
            {
                List<Customer> list = new List<Customer>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from s in dc.tblCustomers
                     select new
                     {
                         s.Id,
                         s.UserId,
                         s.Address,
                         s.City,
                         s.State,
                         s.ZIP,
                         s.Phone
                     })
                     .ToList()
                    .ForEach(customer => list.Add(new Customer
                    {
                        Id = customer.Id,
                        UserId = customer.UserId,
                        Address = customer.Address,
                        City = customer.City,
                        State = customer.State,
                        ZIP = customer.ZIP,
                        Phone = customer.Phone
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
