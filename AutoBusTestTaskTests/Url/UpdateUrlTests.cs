using AutoBusTestTask.Services;
using Microsoft.EntityFrameworkCore;

namespace AutoBusTestTaskTests.Url
{
    public class UpdateUrlTests : TestBase
    {
        [Fact]
        public async Task UpdateUrl_Success()
        {
            // Arrange
            var handler = new UrlRepository(Context);
            var updatedShortUrl = "https://localhost:7100/12345";

            // Act
            await handler.UpdateUrlAsync(new AutoBusTestTask.Models.Url
            {
                Id = UrlContextFactory.UrlIdForUpdate,
                ShortUrl = updatedShortUrl,
            });

            // Assert
            Assert.NotNull(await Context.Urls.SingleOrDefaultAsync(url =>
                url.Id == UrlContextFactory.UrlIdForUpdate &&
                url.ShortUrl == updatedShortUrl));
        }
    }
}
