using AutoBusTestTask.Services;
using Shouldly;

namespace AutoBusTestTaskTests.Url
{
    public class GetUrlTests : TestBase
    {
        [Fact]
        public async Task GetUrl_Success()
        {
            // Arrange
            var handler = new UrlRepository(Context);

            // Act
            var result = await handler.GetUrlAsync(Guid.Parse("A88661F1-5516-445E-8C28-BBC2549EDAB8"));

            // Assert
            result.ShouldBeOfType<AutoBusTestTask.Models.Url>();
            result.ShortUrl.ShouldBe("https://localhost:7100/aed17");
        }
        [Fact]
        public async Task GetUrlShortUrl_Success()
        {
            // Arrange
            var handler = new UrlRepository(Context);

            // Act
            var result = await handler.GetUrlAsync("ofhdt");

            // Assert
            result.ShouldBeOfType<AutoBusTestTask.Models.Url>();
            result.Id.ShouldBe(Guid.Parse("45492178-69F7-448A-96F5-7D4DDDB6F43F"));
        }
        [Fact]
        public async Task GetUrlAsyncThrowTable_Success()
        {
            // Arrange
            var handler = new UrlRepository(Context);

            // Act
            var result = await handler.GetUrlAsyncThrowTable("https://localhost:7100/jkrbj");

            // Assert
            result.ShouldBeOfType<AutoBusTestTask.Models.Url>();
            result.Id.ShouldBe(Guid.Parse("6516FEAB-2B95-4F6E-9C1B-5B61FB470565"));
        }
    }
}
