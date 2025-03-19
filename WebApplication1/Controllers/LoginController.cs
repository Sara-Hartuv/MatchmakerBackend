using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repository.Entities;
using Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IRegistrationAndLogin<User> _userRegistrationAndLogin;
        private readonly IConfiguration config;
        public LoginController(IRegistrationAndLogin<User> userRegistrationAndLogin, IConfiguration config)
        {
            this._userRegistrationAndLogin = userRegistrationAndLogin;
            this.config = config;
        }


        // POST api/<LoginController>
        [HttpPost("login")]
        public IActionResult Login([FromForm] string email, [FromForm] string password)
        {

            var user = _userRegistrationAndLogin.Authenticate(email, password);
            if (user != null)
            {
                var token = _userRegistrationAndLogin.Generate(user);
                return Ok(token);
            }
            else if (email == config["Admin:Email"] && password == config["Admin:Password"])
            {
                User admin = new User();
                admin.Email = email;
                admin.Password = password;
                var token = _userRegistrationAndLogin.Generate(admin);
                return Ok(token);
            }
            return BadRequest("user does not exist");
        }

        // POST api/<LoginController>
        [HttpPost("signup")]
        public IActionResult SignUp([FromForm] string email, [FromForm] string password, [FromForm] string userType)
        {
            var user = _userRegistrationAndLogin.Authenticate(email, password, userType);
            if (user == null)
            {
                User u = new User();
                u.Email = email;
                u.Password = password;
                _userRegistrationAndLogin.AddItem(u, userType);
                var token = _userRegistrationAndLogin.Generate(u);
                return Ok(token);
            }
            return BadRequest("user is exist");
        }



    }
}
