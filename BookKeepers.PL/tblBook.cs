using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.PL
{
    public class tblBook
    {
        public int Id { get; set; }
        public float Cost { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int SubjectId { get; set; }
        public string? Title { get; set; }
        public string? Year { get; set; }
        public string? Photo { get; set; }
        public string? ISBN { get; set; }
        public string? Condition { get; set; }
        public string? Description { get; set; }
    }
}
