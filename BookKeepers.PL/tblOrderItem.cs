using System;

namespace BookKeepers.PL
{
    public class tblOrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public string? Photo { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public virtual tblBook Book { get; set; }
        public virtual tblOrder Order { get; set; }
    }
}
