using AutoBusTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoBusTestTask.Interfaces
{
    public interface IAutoBusTestTaskDbContext
    {
        DbSet<Url> Urls { get; set; }
        int SaveChanges();

    }
}
