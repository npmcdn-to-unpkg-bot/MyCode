using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1
{
    public class HomeController : Controller
    {
        [HttpGet("/{name}")]
        public IActionResult Index(string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}
