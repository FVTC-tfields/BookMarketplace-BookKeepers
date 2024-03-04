using BookKeepers.BL.Models;
using BookKeepers.PL;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public class LoginFailureException : Exception
    {
        public LoginFailureException() : base("Cannot log in with these credentials. You IP Address has been saved.")
        {

        }
        public LoginFailureException(string message) : base(message)
        {

        }
    }

    public static class UserManager
    {
        //public static string GetHash(string password)
        //{
        //    using (var hasher = SHA1.Create())
        //    {
        //        var hashbytes = Encoding.UTF8.GetBytes(password);
        //        return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
        //    }
        //}

        public static int DeleteAll()
        {
            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    dc.tblUsers.RemoveRange(dc.tblUsers.ToList());
                    return dc.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Insert(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUser entity = new tblUser();

                    entity.Id = user.Id;
                    entity.UserName = user.UserName;
                    entity.FirstName = user.FirstName;
                    entity.LastName = user.LastName;
                    entity.UserId = user.UserId;
                    entity.Password = user.Password;

                    // IMPORTANT - BACK FILL THE ID
                    user.Id = entity.Id;

                    dc.tblUsers.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }

                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.UserId))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (BookKeepersEntities dc = new BookKeepersEntities())
                        {
                            tblUser tblUser = dc.tblUsers.FirstOrDefault(u => u.UserId == user.UserId);
                            if (tblUser != null)
                            {
                                if (tblUser.Password == user.Password)
                                {
                                    // Login successful
                                    user.Id = tblUser.Id;
                                    user.FirstName = tblUser.FirstName;
                                    user.LastName = tblUser.LastName;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException();
                                }
                            }
                            else
                            {
                                throw new LoginFailureException("UserId was not found.");
                            }
                        }
                    }
                    else
                    {
                        throw new LoginFailureException("Password was not set.");
                    }
                }
                else
                {
                    throw new LoginFailureException("UserId was not set.");
                }
            }
            catch (LoginFailureException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Seed()
        {
            using (BookKeepersEntities dc = new BookKeepersEntities())
            {
                try
                {
                    if (!dc.tblUsers.Any())
                    {
                        User user = new User
                        {
                            UserId = "test",
                            UserName = "test",
                            FirstName = "John",
                            LastName = "Doe",
                            Password = "testing"
                        };
                        Insert(user);

                        user = new User
                        {
                            UserId = "tfields",
                            UserName = "tfields",
                            FirstName = "Tyler",
                            LastName = "Fields",
                            Password = "larry"
                        };
                        Insert(user);
                    }
                   
                }
                catch (Exception e)
                {
                    var x = 0;
                }
            }
        }
        public static int Update(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblUser entity = dc.tblUsers.FirstOrDefault(s => s.Id == user.Id);

                    if (entity != null)
                    {
                        entity.UserId = user.UserId;
                        entity.FirstName = user.FirstName;
                        entity.LastName = user.LastName;
                        entity.Password = user.Password;
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
        public static List<User> Load()
        {
            try
            {
                List<User> list = new List<User>();

                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    //var stuff = dc.tblUser.ToList();

                    (from s in dc.tblUsers
                     select new
                     {
                         s.Id,
                         s.UserId,
                         s.FirstName,
                         s.LastName,
                         s.Password

                     })
                     .ToList()
                    .ForEach(user => list.Add(new User
                    {
                        Id = user.Id,
                        UserId = user.UserId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Password = user.Password
                    }));
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static User LoadById(int id)
        {
            try
            {
                using (BookKeepersEntities dc = new BookKeepersEntities())
                {
                    tblUser entity = dc.tblUsers.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        return new User
                        {
                            Id = entity.Id,
                            UserId = entity.UserId,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            Password = entity.Password

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
    }
}
