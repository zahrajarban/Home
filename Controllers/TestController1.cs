using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Home.Controllers
{
    [Authorize]
    public class TestController1 : Controller
    {
        [HttpGet]
        public async Task <IActionResult> Test()
        {
            return Ok("you are Authorized...");
        }
    }
}
