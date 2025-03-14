using api_auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            return StatusCode(501, "Not Implemented");
        }

        [Consumes("application/json")]
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            return StatusCode(501, "Not Implemented");
        }
    }
}
