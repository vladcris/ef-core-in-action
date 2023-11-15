namespace ef_core_data.Models;
public class Tag
{
    public string TagId { get; set; }

    //many-to-many without other info besides key
    public ICollection<Book>? Books { get; set; }
}
