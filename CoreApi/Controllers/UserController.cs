using Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreApi.Service;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<User> _userService;
        private readonly IConfiguration _configuration;


        public UserController(IService<User> service, IConfiguration configuration)
        {
            _userService = service;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var secretKey = _configuration["JWT:SigningKey"];
            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];

            if (request.Username == "admin" && request.Password == "password") // Just a demo
            {
                var tokenService = new JwtTokenGenerator();
                var token = tokenService.GenerateToken(request.Username, secretKey, issuer, audience);
                return Ok(new { token });
            }

            return Unauthorized();
        }

       


        private static readonly List<User> Users = new List<User>
        {
            new User { Id = 1, UserName = "alice", Email = "alice@example.com" },
            new User { Id = 2, UserName = "bob", Email = "bob@example.com" }
        };

        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
    

            return Ok(Users);
        }

        // GET: api/users/1
        [HttpGet("{id}/{color}")]
        public ActionResult<User> GetById(int id, string color)
        {
            var user = _userService.RetrieveById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/users
        [HttpGet]
        [Route("GetString/{id?}")]
        public ActionResult<string> GetString(int? id)
        {
            if (id.HasValue)
            {
                return Ok($"Hello world {id}");
            }
            else
            {
                return Ok($"Hello world {id}");
            }

        }

       
    }
}
