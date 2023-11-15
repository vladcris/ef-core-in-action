using ef_core_data;
using ef_core_service.BookServices.QueryObjects;
using static ef_core_service.BookServices.QueryObjects.BookListDtoFilter;

namespace ef_core_service.BookServices.Concrete;
public class BookFilterDropdownService
{
    private readonly AppDbContext _context;

    public BookFilterDropdownService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<DropdownTuple> GetFilterDropdownValues(BooksFilterBy filterBy) {
        var list = filterBy switch {
            BooksFilterBy.NoFilterer => new List<DropdownTuple>(),
            BooksFilterBy.ByVotes => new List<DropdownTuple>() {
                new DropdownTuple {Value = "4", Text = "4 stars and up"},
                new DropdownTuple {Value = "3", Text = "3 stars and up"},
                new DropdownTuple {Value = "2", Text = "2 stars and up"},
                new DropdownTuple {Value = "1", Text = "1 star and up"},
            },
            BooksFilterBy.ByPublicationYear => GetByYear(),
            BooksFilterBy.ByTags => _context.Tags.Select(x => new DropdownTuple { Text = x.TagId, Value = x.TagId }).ToArray(),
            _ => throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null)
        };  

        return list;

        IEnumerable<DropdownTuple> GetByYear() {
            var today = DateTimeOffset.UtcNow;
            var list = _context.Books
                .Where(x => x.PublishedOn < today)
                .Select(y => y.PublishedOn.Year)
                .Distinct()
                .OrderByDescending(x => x)
                .Select(x => new DropdownTuple { Text = x.ToString(), Value = x.ToString() })
                .ToList();

            var commingSoon = _context.Books.Any(x => x.PublishedOn > today);
            if (commingSoon) {
                list.Insert(0, new DropdownTuple { Text = AllBooksNotPublishedString, Value = AllBooksNotPublishedString });
            }

            return list;
        }
    }
}
