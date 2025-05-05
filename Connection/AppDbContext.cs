using LocadoraCarros.Models;
using Microsoft.EntityFrameworkCore;

namespace LocadoraCarros.Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Carro> Carros { get; set; }
    }
}
