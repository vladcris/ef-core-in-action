namespace ef_core_data.Models;
public class Review
{
    public int ReviewId { get; set; }
    public string? VoterName { get; set; }
    public int NumStars { get; set; }
    public string? Comment { get; set; }

    //foreign key
    public int BookId { get; set; }
}
