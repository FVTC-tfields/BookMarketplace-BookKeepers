using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int SubjectId { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public string Photo { get; set; }
        public string ISBN { get; set; }
        public string Status { get; set; }
    }
}
