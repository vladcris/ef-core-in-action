
namespace ef_core_data;
public class ReplacementUserIdService : IUserIdService
{
    public Guid GetUserId() {
        return Guid.Empty;
    }
}
