using ProjectASP.NET_14040.Models;

namespace ProjectASP.NET_14040.Data.ViewModels
{
    public class NewBookDropdownsVM
    {
        public NewBookDropdownsVM()
        {
            Authors = new List<Author>();
            
            BookStores = new List<BookStore>();
        }

        public List<Author> Authors { get; set; }
      
        public List<BookStore> BookStores { get; set; }
    }
}
