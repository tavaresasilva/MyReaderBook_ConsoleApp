using System.Collections.Generic;

namespace MyReaderBook.Domain
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<Book> BooksWritten{ get; set; }
    }
}
