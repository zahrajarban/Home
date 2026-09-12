using Microsoft.AspNetCore.Mvc;

namespace Home.Controllers
{
    public class TestController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
