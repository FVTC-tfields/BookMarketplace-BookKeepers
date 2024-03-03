using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL.Models
{
    public   class ShoppingCart
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public int NumberOfItems { get; set; }
        public float SubTotal { get; set; }
        public float Tax { get; set; }
        public float Total { get; set; }
    }
}
