using BookKeepers.BL;
using BookKeepers.BL.Models;
using System.ComponentModel.DataAnnotations;

namespace BookKeepers.UI.ViewModels
{
    public class BookViewModel
    {
        public Book book { get; set; }
        public List<Author> AuthorList {  get; set; }
        public List<Publisher> PublisherList { get; set; }
        public List<Subject> SubjectList { get; set; }
        public List<Condition> ConditionList { get; set; }
        public BookViewModel()
        {
            book = new Book();

            AuthorList = AuthorManager.Load();
            PublisherList = PublisherManager.Load();
            SubjectList = SubjectManager.Load();
            ConditionList = ConditionManager.Load();
        }

    }
}
