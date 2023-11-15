using Bogus.DataSets;
using Bogus;
using ef_core_data.Models;

namespace ef_core_web;

public static class SeedDatabase
{
    public static Faker<Book> GetBookGenerator() {
        return new Faker<Book>()
            //.RuleFor(v => v.BookId, f => f.IndexFaker+1)
            .RuleFor(v => v.Title, f => f.Lorem.Text())
            .RuleFor(v => v.Description, f => f.Lorem.Paragraph(2))
            .RuleFor(v => v.PublishedOn, f => f.Date.BetweenOffset(DateTimeOffset.UtcNow.AddYears(-50), DateTimeOffset.UtcNow.AddYears(2)))
            .RuleFor(v => v.Publisher, f => f.Name.FullName())
            .RuleFor(v => v.Price, f => f.Random.Decimal(1, 1000))
            .RuleFor(v => v.ImageUrl, f => f.Image.PicsumUrl())
            .RuleFor(v => v.SoftDeleted, _ => false);
    }

    public static Faker<Author> GetAuthGenerator() {
        return new Faker<Author>()
            //.RuleFor(v => v.AuthorId, f => f.IndexFaker+1)
            .RuleFor(v => v.Name, f => f.Name.FullName());
    }

    public static Faker<PriceOffer> GetPriceGenerator() {
        return new Faker<PriceOffer>()
            //.RuleFor(v => v.PriceOfferId, f => f.IndexFaker+1)
            .RuleFor(v => v.NewPrice, f => f.Random.Decimal(1, 800))
            .RuleFor(v => v.PromotionalText, f => f.Lorem.Paragraph(2));
    }

    public static Faker<Review> GetReviewGenerator() {
        return new Faker<Review>()
            //.RuleFor(v => v.ReviewId, f => f.IndexFaker+1)
            .RuleFor(v => v.VoterName, f => f.Name.FullName())
            .RuleFor(v => v.NumStars, f => f.Random.Int(1, 5))
            .RuleFor(v => v.Comment, f => f.Lorem.Paragraphs(4));
    }

}


