using BlogBackend.Services;
using BlogBackend.Services.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Result<bool>> Login([FromBody] LoginRequestDTO request)
        {
            if(string.IsNullOrWhiteSpace(request.username) || string.IsNullOrWhiteSpace(request.password))
                return BadRequest();

            var username = Environment.GetEnvironmentVariable("USERNAME");
            var password = Environment.GetEnvironmentVariable("PASSWORD");

            if (request.username.Equals(username) && request.password.Equals(password))
            {
                return Ok(Result<bool>.Ok(true));
            }
            else
            {
                return Unauthorized(Result<bool>.Ok(false,"Kullanıcı bilgileri hatalı"));
            }
        }
    }
}
