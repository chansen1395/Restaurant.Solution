using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Food.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Food.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly FoodContext _db;
    
    public RestaurantsController(FoodContext db) {
      _db = db;
    }

    public ActionResult Index() {
      List<Restaurant> model = _db.Restaurant_Info.Include(restaurant => restaurant.Cuisine).ToList();
      return View(model);
    }

    public ActionResult Create() {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "CuisineName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant) {
      _db.Restaurant_Info.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details (int id) {
      Restaurant thisRestaurant = _db.Restaurant_Info.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    public ActionResult Edit (int id) {
      var thisRestaurant = _db.Restaurant_Info.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      ViewBag.CuisineId = new SelectList (_db.Cuisines, "CuisineId", "CuisineName");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit (Restaurant restaurant) {
      _db.Entry(restaurant).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id) {
      var thisRestaurant = _db.Restaurant_Info.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id) {
      var thisRestaurant = _db.Restaurant_Info.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      _db.Restaurant_Info.Remove(thisRestaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }


    public ActionResult Search() 
    {
      
      return View();
    }

    [HttpPost]
    public ActionResult Search(string RestaurantName) 
    {
      string searchName = RestaurantName.ToLower();
      List<Restaurant> searchResults = _db.Restaurant_Info.Where(restaurant => restaurant.RestaurantName.ToLower().Contains(searchName)).ToList();
      return View("Index", searchResults);
    }
  }

}
