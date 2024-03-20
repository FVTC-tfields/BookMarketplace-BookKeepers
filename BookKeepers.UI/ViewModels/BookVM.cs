using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookKeepers.BL;
using BookKeepers.BL.Models;

namespace BookKeepers.UI.ViewModels
{
    public class BookVM
    {
        public List<Author> Authors { get; set; } // get all the authors
        public List<Subject> Subjects { get; set; }
       public BookVM() 
        {
            Authors = AuthorManager.Load();
            Subjects = SubjectManager.Load();
        
        }
    }
}
