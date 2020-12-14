using Microsoft.EntityFrameworkCore;
using Domain.Models;
namespace Domain.Infra
{
    public class ServiceDbContext : DbContext
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseInMemoryDatabase("dbUltimate");
        }
        public DbSet<Produto> Produtos { get; set; }
    }
}