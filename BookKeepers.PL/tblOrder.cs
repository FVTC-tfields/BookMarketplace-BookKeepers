using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.PL
{
    public class tblOrder
    {
        public int Id { get; set; }

        [DisplayName("Customer Id")]
        public int CustomerId { get; set; }

        [DisplayName("User Id")]
        public int UserId { get; set; }

        [DisplayName("Order Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Ship Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ShipDate { get; set; }
        public virtual ICollection<tblOrderItem> OrderItems { get; set; }
        public float SubTotal { get; set; }

        public float Total { get; set; }

        public float Tax { get; set; }
    }
}
