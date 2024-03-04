using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.PL
{
    public class tblPost
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int ConditionId { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
    }
}
