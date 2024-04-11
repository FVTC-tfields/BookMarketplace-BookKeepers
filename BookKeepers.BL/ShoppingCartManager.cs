﻿using BookKeepers.BL.Models;
using BookKeepers.PL;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL
{
    public static class ShoppingCartManager
    {
        public static void Checkout(ShoppingCart cart)
        {
            Order order = new Order();
            order.CustomerId = cart.CustomerId;
            order.OrderDate = DateTime.Now;
            order.UserId = cart.UserId;
            order.ShipDate = DateTime.Now.AddDays(3);
            OrderManager.Insert(order);
        }

        public static void Add(ShoppingCart cart, Book book)
        {
            if (!cart.Items.Any(n => n.Id == book.Id))
                cart.Add(book);
            else
                cart.Items.Where(n => n.Id == book.Id).FirstOrDefault().Quantity++;
        }

        public static void AssignToCustomer()
        {

        }


        public static void Remove(ShoppingCart cart, Book book)
        {
            cart.Remove(book);
        }

    }
}
