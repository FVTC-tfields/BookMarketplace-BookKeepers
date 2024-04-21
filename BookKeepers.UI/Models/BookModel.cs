using BookKeepers.BL.Models;
using System.ComponentModel.DataAnnotations;

namespace BookKeepers.UI.Models
{
    public class BookModel : Book
    {
        [Display(Name = "Photo")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverPhotoUrl { get; set; }
    }
}
