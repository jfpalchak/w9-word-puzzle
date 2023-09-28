using Microsoft.AspNetCore.Mvc;

namespace WordPuzzle.Controllers
{
  public class HomeController : Controller
  {
    // SPLASH PAGE
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}