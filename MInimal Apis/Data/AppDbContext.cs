using Microsoft.EntityFrameworkCore;
using MInimal_Apis.Models;

namespace MInimal_Apis.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        { }

        public DbSet<Item> Items { get; set; }
    }
}
