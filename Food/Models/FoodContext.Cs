using Microsoft.EntityFrameworkCore;

namespace Food.Models
{
  public class FoodContext : AddDbContext
  {
    public DbSet<Cuisine> Cuisines {get; set;}
    public DbSet<Restaurant> Restaurants {get; set;}

    public FoodContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}