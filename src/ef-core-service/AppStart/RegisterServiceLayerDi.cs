using ef_core_service.BookServices.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace ef_core_service.AppStart;
public static class RegisterServiceLayerDi
{
    public static void RegisterServiceLayer(this IServiceCollection services) {
        services.AddScoped<ListBooksService>();
        services.AddScoped<BookFilterDropdownService>();
    }
}
