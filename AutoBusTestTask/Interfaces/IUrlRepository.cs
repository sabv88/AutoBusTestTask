using AutoBusTestTask.Models;

namespace AutoBusTestTask.Interfaces
{
    public interface IUrlRepository
    {
        Task<List<Url>> GetUrlListAsync();
        Task<Url> GetUrlAsync(string shortUrl);
        Task<Url> GetUrlAsyncThrowTable(string shortUrl);
        Task<Url> GetUrlAsync(Guid id);
        Task CreateUrlAsync(Url url);
        Task UpdateUrlAsync(Url url);
        void DeleteUrl(Url url);
    }
}
