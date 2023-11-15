using ef_core_data;
using ef_core_data.Models;
using ef_core_service.BookServices;
using ef_core_service.BookServices.Concrete;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ef_core_service.BookServices.QueryObjects.BookListDtoFilter;

namespace ef_core_web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ListBooksService _listBooksService;
    private readonly BookFilterDropdownService _dropdownService;

    public Book? Book { get; set; }

    public IndexModel(ILogger<IndexModel> logger, ListBooksService listBooksService, BookFilterDropdownService dropdownService)
    {
        _logger = logger;
        _listBooksService = listBooksService;
        _dropdownService = dropdownService;
    }

    public void OnGet() {
        var options = new SortFilterPageOptions();

        var books = _listBooksService.SortFilterPage(options).ToArray();

        var drop = _dropdownService.GetFilterDropdownValues(BooksFilterBy.ByPublicationYear);
    }
}
  