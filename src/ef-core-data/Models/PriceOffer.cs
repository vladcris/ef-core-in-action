namespace ef_core_data.Models;
public class PriceOffer
{
    public int PriceOfferId { get; set; }
    public decimal NewPrice { get; set; }
    public string? PromotionalText { get; set; }

    //foreign key
    public int BookId { get; set; }
}
