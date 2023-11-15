namespace ef_core_data.Models;

// link table for many-to-many relationship
public class Book_Author
{
    public int BookId { get; set; }
    public Book? Book { get; set; }

    public int AuthorId { get; set; }
    public Author? Author { get; set; }

    public byte Order { get; set; }
}
