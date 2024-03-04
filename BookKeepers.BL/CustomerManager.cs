using BookKeepers.BL.Models;
using BookKeepers.PL;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public class CustomerManager
    {
        public static List<Customer> Load()
        {
            try
            {
                List<Customer> rows = new List<Customer>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    (from s in dc.tblCustomers
                     select new
                     {
                         s.Id,
                         s.FirstName,
                         s.LastName,
                         s.Phone,
                         s.State,
                         s.City,
                         s.Address,
                         s.ZIP,
                         s.UserId
                     }).ToList()
                     .ForEach(Customer => rows.Add(new Customer
                     {
                         Id = Customer.Id,
                         Phone = Customer.Phone,
                         State = Customer.State,
                         City = Customer.City,
                         Address = Customer.Address,
                         ZIP = Customer.ZIP,
                         UserId = Customer.UserId
                     }));
                }

                return rows;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Customer LoadById(int id)
        {
            try
            {


                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    tblCustomer row = dc.tblCustomers.Where(s => s.Id == id).FirstOrDefault();

                    if (row != null)
                    {
                        return new Customer
                        {
                            Id = row.Id,
                            Phone = row.Phone,
                            State = row.State,
                            City = row.City,
                            Address = row.Address,
                            ZIP = row.ZIP,
                            UserId = row.UserId
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

        public static int Insert(Customer customer, bool rollback = false)
        {

            try
            {
                int results = 0;

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblCustomer row = new tblCustomer();

                    row.Id = dc.tblCustomers.Any() ? dc.tblCustomers.Max(s => s.Id) + 1 : 1;

                    row.Address = customer.Address;
                    row.ZIP = customer.ZIP;
                    row.UserId = customer.UserId;
                    row.City = customer.City;
                    row.Address = customer.Address;
                    row.Phone = customer.Phone;
                    row.State = customer.State;

                    customer.Id = row.Id;

                    dc.tblCustomers.Add(row);

                    results = dc.SaveChanges();

                    if (rollback) dbContextTransaction.Rollback();
                }

                return results;
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

                    tblCustomer row = dc.tblCustomers.FirstOrDefault(s => s.Id == id);


                    if (row != null)
                    {
                        dc.tblCustomers.Remove(row);
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

        public static int Update(Customer customer, bool rollback = false)
        {

            try
            {
                int results = 0;

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblCustomer row = dc.tblCustomers.FirstOrDefault(s => s.Id == customer.Id);

                    if (row != null)
                    {

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

        public static int GetAssociateCustomerId(int userId)
        {
            try
            {


                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    tblCustomer row = dc.tblCustomers.Where(s => s.UserId == userId).FirstOrDefault();

                    if (row != null)
                    {
                        return row.Id;

                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int AssignUserId(JSonModel jSonModel, bool rollback = false)
        {

            try
            {
                int results = 0;

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;

                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblCustomer row = dc.tblCustomers.FirstOrDefault(s => s.Id == jSonModel.customerId);

                    if (row != null)
                    {
                        row.UserId = jSonModel.userId;

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
