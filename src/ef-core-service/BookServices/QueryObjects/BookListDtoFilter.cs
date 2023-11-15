
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ef_core_service.BookServices.QueryObjects;
public static class BookListDtoFilter
{
    public enum BooksFilterBy {
        [Display(Name = "All")] NoFilterer = 0,
        [Display(Name = "By Votes ...")] ByVotes,
        [Display(Name = "By Categories ...")] ByTags,
        [Display(Name = "By Year published ...")] ByPublicationYear
    }
    public const string AllBooksNotPublishedString = "Coming Soon";
    public static IQueryable<BookListDto> FilterBooksBy(this IQueryable<BookListDto> books,
                                                        BooksFilterBy filterBy,
                                                        string filterValue) {
        if(string.IsNullOrEmpty(filterValue)) {
            return books;
        }

        var queryBooks = filterBy switch {
            BooksFilterBy.NoFilterer => books,
            BooksFilterBy.ByVotes => FilterByVotes(),
            BooksFilterBy.ByTags => FilterByTags(),
            BooksFilterBy.ByPublicationYear => FilterByPublicationYear(),
            _ => throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null)
        };

        return queryBooks;

        //local functions
        IQueryable<BookListDto> FilterByVotes() {
            int vote = int.Parse(filterValue);
            return books.Where(x => x.ReviewsAverageVotes > vote);
        }
        IQueryable<BookListDto> FilterByTags() {
            return books.Where(x => x.TagStrings!.Any(y => y.Equals(filterValue)));
        }
        IQueryable<BookListDto> FilterByPublicationYear() {
            if(filterValue == AllBooksNotPublishedString) {
                return books.Where(x => x.PublishedOn > DateTime.UtcNow);
            }

            var filterByYear = int.Parse(filterValue);
            return books.Where(x => x.PublishedOn.Year == filterByYear &&
                x.PublishedOn <= DateTime.UtcNow);
        }
    }
}
