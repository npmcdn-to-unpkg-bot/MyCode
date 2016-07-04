using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1
{
    public class HomeController
    {
        [HttpGet("/{name}")]
        public string Index(string name)
        {
            return $"Hello {name}";
        }
    }
}
