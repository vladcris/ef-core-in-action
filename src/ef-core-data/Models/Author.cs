namespace ef_core_data.Models;
public class Author
{
    public int AuthorId { get; set; }
    public string? Name { get; set; }

    //many-to-many
    public ICollection<Book_Author>? BookLink { get; set; }
}


 