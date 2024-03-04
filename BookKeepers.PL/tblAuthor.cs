using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.PL
{
    public class tblAuthor
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
