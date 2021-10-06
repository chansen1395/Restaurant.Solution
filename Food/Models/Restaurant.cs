namespace Food.Models
{
  public class Restaurant
  {
    public int RestaurantId {get; set;}
    public string RestaurantName {get; set;}
    public string RestaurantInfo {get; set;}
    public bool RestaurantPositive {get; set;}
    public int CuisineId {get; set;}
    public virtual Cuisine Cuisine {get; set;}
  }
}