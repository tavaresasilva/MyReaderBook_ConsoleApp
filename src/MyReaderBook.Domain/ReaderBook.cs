namespace MyReaderBook.Domain
{
    public class ReaderBook
    {
        public int BookId { get; set; }
        public int ReaderId { get; set; }

        public virtual Reader Reader { get; set; }
        public virtual Book Book { get; set; }
    }
}
