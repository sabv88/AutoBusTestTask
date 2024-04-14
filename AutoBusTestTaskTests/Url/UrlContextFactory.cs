using AutoBusTestTask.Data;
using Microsoft.EntityFrameworkCore;
using AutoBusTestTask.Models;

namespace AutoBusTestTaskTests.Url
{
    public class UrlContextFactory
    {
        public static Guid UrlIdForDelete = Guid.NewGuid();
        public static Guid UrlIdForUpdate = Guid.NewGuid();

        public static AutoBusTestTaskDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AutoBusTestTaskDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new AutoBusTestTaskDbContext(options);
            context.Database.EnsureCreated();
            context.Urls.AddRange(
                new AutoBusTestTask.Models.Url
                {
                    Id = Guid.Parse("45492178-69F7-448A-96F5-7D4DDDB6F43F"),
                    OriginalUrl = "https://www.twitch.tv",
                    ShortUrl = "https://localhost:7100/ofhdt",
                    CreationDate = DateTime.Now,
                    RedirectCount = 0
                },
                new AutoBusTestTask.Models.Url
                {
                    Id = Guid.Parse("A88661F1-5516-445E-8C28-BBC2549EDAB8"),
                    OriginalUrl = "https://www.youtube.com",
                    ShortUrl = "https://localhost:7100/aed17",
                    CreationDate = DateTime.Now,
                    RedirectCount = 0
                },
                 new AutoBusTestTask.Models.Url
                 {
                     Id = Guid.Parse("6516FEAB-2B95-4F6E-9C1B-5B61FB470565"),
                     OriginalUrl = "https://habr.com/ru/feed/",
                     ShortUrl = "https://localhost:7100/jkrbj",
                     CreationDate = DateTime.Now,
                     RedirectCount = 0
                 },
                new AutoBusTestTask.Models.Url
                {
                    Id = UrlIdForDelete,
                    OriginalUrl = "https://learn.microsoft.com/ru-ru/",
                    ShortUrl = "https://localhost:7100/12345",
                    CreationDate = DateTime.Now,
                    RedirectCount = 0
                },
                new AutoBusTestTask.Models.Url
                {
                    Id = UrlIdForUpdate,
                    OriginalUrl = "https://learn.microsoft.com/ru-ru/",
                    ShortUrl = "https://localhost:7100/12345",
                    CreationDate = DateTime.Now,
                    RedirectCount = 0
                }
            );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(AutoBusTestTaskDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
