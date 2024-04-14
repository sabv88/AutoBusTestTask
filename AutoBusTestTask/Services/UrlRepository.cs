using AutoBusTestTask.Interfaces;
using AutoBusTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoBusTestTask.Services
{
    public class UrlRepository : IUrlRepository
    {
        private IAutoBusTestTaskDbContext _dbContext;

        public UrlRepository(IAutoBusTestTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Url>> GetUrlListAsync()
        {
            return await _dbContext.Urls.ToListAsync();
        }
        public async Task<Url> GetUrlAsync(Guid id)
        {
            return await _dbContext.Urls.FirstOrDefaultAsync((url => url.Id == id));
        }
        public async Task<Url> GetUrlAsync(string shortUrl)
        {
            return await _dbContext.Urls.FirstOrDefaultAsync((url =>
                   url.ShortUrl == "https://localhost:7100/" + shortUrl));
        }
        public async Task<Url> GetUrlAsyncThrowTable(string shortUrl)
        {
            return await _dbContext.Urls.FirstOrDefaultAsync((url =>
                   url.ShortUrl == shortUrl));
        }
        public async Task CreateUrlAsync(Url url)
        {
             await _dbContext.Urls.AddAsync(url);
            _dbContext.SaveChanges();
        }
        public async Task UpdateUrlAsync(Url url)
        {
            var entity = await _dbContext.Urls.FirstOrDefaultAsync((URL => URL.Id == url.Id));
            entity.OriginalUrl = url.OriginalUrl;
            entity.ShortUrl = url.ShortUrl;
            entity.CreationDate = url.CreationDate;
            entity.RedirectCount = url.RedirectCount;
            _dbContext.SaveChanges();
        }

        public void DeleteUrl(Url url)
        {
            _dbContext.Urls.Remove(url);
            _dbContext.SaveChanges();
        }
    }
}
