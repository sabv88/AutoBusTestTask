using AutoBusTestTask.Services;
using Microsoft.EntityFrameworkCore;

namespace AutoBusTestTaskTests.Url
{
    public class DeleteUrlTests : TestBase
    {
        [Fact]
        public async Task DeleteUrl_Success()
        {
            // Arrange
            var handler = new UrlRepository(Context);

            // Act
            handler.DeleteUrl(Context.Urls.SingleOrDefault(url =>
                url.Id == UrlContextFactory.UrlIdForDelete));

            // Assert
            Assert.Null(Context.Urls.SingleOrDefault(url =>
                url.Id == UrlContextFactory.UrlIdForDelete));
        }
    }
}
