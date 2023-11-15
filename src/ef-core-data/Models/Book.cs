namespace ef_core_data.Models;
public class Book
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset PublishedOn { get; set; }
    public string? Publisher { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }

    public bool SoftDeleted { get; set; }

    // one-to-one
    public PriceOffer? Promotion { get; set; }
    // one-to-many
    public ICollection<Review>? Reviews { get; set; }
    // many-to-many
    public ICollection<Book_Author>? AuthorsLink { get; set; }
    public ICollection<Tag>? Tags { get; set; }

}
