using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public string? Title { get; set; }
        public string? Year { get; set; }
        public string? Photo { get; set; }
        public string? ISBN { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }
        public string? Condition { get; set; }
        [DisplayName("Author")]
        public string? AuthorName { get; set; }
        [DisplayName("Publisher")]
        public string? PublisherName { get; set; }
        [DisplayName("Subject")]
        public string? SubjectName { get; set; }

        [Required]
        public string Description { get; set; }
        
    }
}
