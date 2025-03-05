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
        private readonly IService<User> service;
        private readonly IConfiguration config;
        public LoginController(IService<User> service, IConfiguration config)
        {
            this.service = service;
            this.config = config;
        }
        

        // POST api/<LoginController>
        [HttpPost("login")]
        public IActionResult Login([FromQuery] string email, string password)
        {
            var user = Authenticate(email, password);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return BadRequest("user does not exist");
        }

        // POST api/<LoginController>
        [HttpPost("signup")]
        public IActionResult SignUp([FromQuery] string email, string password)
        {
            var user = Authenticate(email, password);
            if (user == null)
            {
                User u = new User();
                u.Email = email;
                u.Password = password;
                var token = Generate(u);
                return Ok(token);
            }
            return BadRequest("user is exist");
        }

        private string Generate(User user)
        {
            //הקוד להצפנה במערך של ביטים 
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            //אלגוריתם להצפנה
            string role;
            if (user is Candidate)
            {
                role = "candidate";
            }
            else if (user is Matchmaker)
            {
                role = "machmaker";
            }
            else
                role = "user";
            var carditional = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.FirstName+user.LastName),
                new Claim(ClaimTypes.Role,role),
                new Claim(ClaimTypes.NameIdentifier,user.NumId.ToString())
            };

            var token = new JwtSecurityToken(
                config["Jwt:Issuer"], config["Jwt:Audience"]
                , claims,
          expires: DateTime.Now.AddMinutes(30),
              signingCredentials: carditional);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(string email, string password)
        {
            var user = service.GetAll().FirstOrDefault(x => x.Email == email && x.Password == password);
            return user;
        }
    }
}
