using System.Web.Http;

namespace TLMManager.Controller
{
    public class UserController : BaseController
    {




        [HttpGet]
        public string HelloWorld()
        {
            return "HelloWorld";
        }
    }
}
