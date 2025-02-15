﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.PL
{
    public class tblCustomer
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [DisplayName("User Id")]
        public int UserId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZIP { get; set; }
        public string? Phone { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }
        public virtual ICollection<tblOrder> Orders { get; set; }
    }
}
