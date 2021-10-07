using Microsoft.AspNetCore.Mvc;
using Food.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
// using System;
// using System.Web;
// using System.Web.Mvc;
// using System.ComponentModel.DataAnnotations;
// using System.Data.Entity;



namespace Food.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly FoodContext _db;

    public CuisinesController(FoodContext db)
    {
      _db = db;
    }

//*************************************************
    // public ActionResult Index(string searchString) 
    // {           
    //   var cuisines = from m in _db.Cuisines 
    //     select m; 
  
    //   if (!String.IsNullOrEmpty(searchString)) 
    //   { 
    //       cuisines = cuisines.Where(s => s.CuisineName.Contains(searchString)); 
    //   } 

    //   return View(cuisines); 
    // }

    // [HttpPost] 
    // public string Index(FormCollection fc, string searchString) 
    // { 
    //   return "<h3> From [HttpPost]Index: " + searchString + "</h3>"; 
    // }
//*************************************************

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
      _db.Cuisines.Add(cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    public ActionResult Edit(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost]
    public ActionResult Edit (Cuisine cuisine)
    {
      _db.Entry(cuisine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete (int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      _db.Cuisines.Remove(thisCuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}