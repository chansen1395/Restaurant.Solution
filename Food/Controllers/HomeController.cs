using Microsoft.AspNetCore.Mvc;

namespace Food.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public ActionResult Index()
    { return View(); }
  }
}