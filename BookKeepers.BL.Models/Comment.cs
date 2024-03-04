using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }
        public string? Condition { get; set; }
        public string? CreationDate { get; set; }
    }
}
