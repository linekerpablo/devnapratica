using DevNaPraticaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevNaPraticaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly List<User> users = new();
        private static int nextId = 1;

        [HttpPost]
        public IActionResult CreateUser([FromBody]User user)
        {
            if (string.IsNullOrWhiteSpace(user?.Name))
                return BadRequest(new { message = "Nome de usuario e obrigatorio!" });

            user.Id = nextId++;
            users.Add(user);

            return CreatedAtAction(
                nameof(GetUserById),
                new { id = user.Id },
                user
                );
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound(new { message = "Usuario nao encontrado!" });
            return Ok(user);
        }
    }
}
