using System.ComponentModel.DataAnnotations;

namespace ef_core_service.BookServices.QueryObjects;
public static class BookListDtoSort
{
    public enum OrderByOptions {
        [Display(Name = "sort by...")] SimpleOrder = 0,
        [Display(Name = "Votes ↑")] ByVotes,
        [Display(Name = "Publication Date ↑")] ByPublicationDate,
        [Display(Name = "Price ↓")] ByPriceLowestFirst,
        [Display(Name = "Price ↑")] ByPriceHigestFirst
    }
    public static IQueryable<BookListDto> OrderBooksBy(this IQueryable<BookListDto> query, OrderByOptions options) {

        query = options switch {
            OrderByOptions.SimpleOrder => query.OrderByDescending(x => x.BookId),
            OrderByOptions.ByVotes => query.OrderByDescending(x => x.ReviewsAverageVotes),
            OrderByOptions.ByPublicationDate => query.OrderByDescending(x => x.PublishedOn),
            OrderByOptions.ByPriceLowestFirst => query.OrderBy(x => x.ActualPrice),
            OrderByOptions.ByPriceHigestFirst => query.OrderByDescending(x => x.ActualPrice),
            _ => throw new ArgumentOutOfRangeException(nameof(options), options, null)
        };

        return query;   
    }
}
