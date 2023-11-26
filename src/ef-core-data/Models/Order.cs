using System.Net;

namespace ef_core_data.Models;
public class Order
{
    public int OrderId { get; set; }
    public DateTimeOffset DateOrderedUtc { get; set; }
    public Guid CustomerId { get; set; }
    public ICollection<LineItem>? LineItems { get; set; }
    public string? OrderNumber => $"SO{OrderId:D6}";
    public Order()
    {
        DateOrderedUtc = DateTimeOffset.UtcNow;
    }
}
