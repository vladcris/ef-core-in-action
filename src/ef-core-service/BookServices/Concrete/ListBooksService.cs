using ef_core_data;
using ef_core_data.QueryObjects;
using ef_core_service.BookServices.QueryObjects;
using Microsoft.EntityFrameworkCore;

namespace ef_core_service.BookServices.Concrete;
public class ListBooksService
{
    private readonly AppDbContext _context;

    public ListBooksService(AppDbContext context)
    {
        _context = context;
    } 

    public IQueryable<BookListDto> SortFilterPage(SortFilterPageOptions options) {
        var booksQuery = _context.Books
            .AsNoTracking()
            .MapBookToDto()
            .FilterBooksBy(options.FilterBy, options.FilterValue!)
            .OrderBooksBy(options.OrderByOptions);

        options.SetupRestOfDto(booksQuery);

        return booksQuery.Page(options.PageNum - 1, options.PageSize);
    }
}
