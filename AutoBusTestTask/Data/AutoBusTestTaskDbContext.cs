using AutoBusTestTask.Interfaces;
using AutoBusTestTask.Models;
using Microsoft.EntityFrameworkCore;


namespace AutoBusTestTask.Data
{
    public class AutoBusTestTaskDbContext : DbContext, IAutoBusTestTaskDbContext
    {
        public DbSet<Url> Urls { get; set; }

        public AutoBusTestTaskDbContext(DbContextOptions<AutoBusTestTaskDbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
