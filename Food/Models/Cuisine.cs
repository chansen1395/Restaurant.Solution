using System.Collections.Generic;

namespace Food.Models
{
  public class Cuisine
  {
    public Cuisine()
    {
      this.Restaurants = new HashSet<Restaurant>();
    }
    public int CuisineId {get; set;}
    public string CuisineName {get; set;}
    public virtual ICollection<Restaurant> Restaurants {get; set;}
  }
}