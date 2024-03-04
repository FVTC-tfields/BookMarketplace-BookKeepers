using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.PL
{
    public class tblOrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }
        public string? Photo { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
