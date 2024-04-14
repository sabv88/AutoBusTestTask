using AutoBusTestTask.Services;
using Microsoft.EntityFrameworkCore;

namespace AutoBusTestTaskTests.Url
{
    public class CreateUrlTests : TestBase
    {
        [Fact]
        public async Task CreateUrl_Success()
        {
            // Arrange
            var handler = new UrlRepository(Context);
            var id = Guid.NewGuid();
            var originalUrl = "";
            var shortUrl = "";
            var creationDate = DateTime.Now;
            var redirectCount = 0;

            // Act
             await handler.CreateUrlAsync(
                new AutoBusTestTask.Models.Url
                {
                    Id = id,
                    OriginalUrl = originalUrl,
                    ShortUrl = shortUrl,
                    CreationDate = creationDate,
                    RedirectCount = redirectCount
                });

            // Assert
            Assert.NotNull(
                await Context.Urls.SingleOrDefaultAsync(url =>
                    url.Id == id && 
                    url.OriginalUrl == originalUrl &&
                    url.ShortUrl == shortUrl &&
                    url.CreationDate == creationDate &&
                    url.RedirectCount == redirectCount));
        }
    }
}
