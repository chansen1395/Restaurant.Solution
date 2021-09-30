using Microsoft.AspNetCore.Mvc;

namespace TemplateName.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public ActionResult Index()
    { return View(); }
  }
}