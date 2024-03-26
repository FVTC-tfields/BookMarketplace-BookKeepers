using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeepers.BL.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [DisplayName("Publisher Name")]
        public string? Name { get; set; }
    }
}
