using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL.Models
{
    public class Home
    {
        public List<Book> Books { get; set; }

        public Home() => Books = new List<Book>();
    }
}
