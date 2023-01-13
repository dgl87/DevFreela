using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly ExampleClass _exampleClass;
        public UsersController(ExampleClass exampleClass)
        {
            _exampleClass = exampleClass;
        }
        // api/users/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        // api/users
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel createUser)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, createUser);
        }

        // api/users/3/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }
    }
}
