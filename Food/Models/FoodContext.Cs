using Microsoft.EntityFrameworkCore;

namespace Food.Models
{
  public class FoodContext : DbContext
  {
    public DbSet<Cuisine> Cuisines {get; set;}
    public DbSet<Restaurant> Restaurant_Info {get; set;}

    public FoodContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}