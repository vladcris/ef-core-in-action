using ef_core_data.Models;

namespace ef_core_service.BookServices.QueryObjects;
public static class BookListDtoSelect
{
    public static IQueryable<BookListDto> MapBookToDto(this IQueryable<Book> books) {
        var book = books.Select(book => new BookListDto {
            BookId = book.BookId,
            Title = book.Title,
            Price = book.Price,
            PublishedOn = book.PublishedOn.DateTime,
            ActualPrice = book.Promotion == null
                ? book.Price
                : book.Promotion.NewPrice,
            PromotionPromotionalText = book.Promotion == null
                ? null
                : book.Promotion.PromotionalText,
            AuthorsOrdered = string.Join(", ",
                book.AuthorsLink!
                .OrderBy(x => x.Order)
                .Select(a => a.Author!.Name)),
            ReviewsCount = book.Reviews!.Count,
            ReviewsAverageVotes = book.Reviews
                .Select(x => (double)x.NumStars)
                .Average(),
            TagStrings = book.Tags!.Select(x => x.TagId).ToArray() ?? default
        }); 

        return book;
    }
}
