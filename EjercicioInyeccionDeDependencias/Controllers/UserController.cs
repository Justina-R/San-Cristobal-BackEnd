using Microsoft.AspNetCore.Mvc;

namespace EjercicioInyeccionDeDependencias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("notificar")]
        public IActionResult Notificar([FromBody] string email)
        {
            _userService.NotifyUser(email);
            return Ok($"Notificación enviada a {email}");
        }

    }
}
