using Home.Models;
using Home.Services;
using Microsoft.AspNetCore.Mvc;
namespace Home.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserModel user)
        {
            var result = await _userService.AddUser(user);
            return Ok(result);
        }
    }
}