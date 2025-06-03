using Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<User> _userService;


        public UserController(IService<User> service)
        {
            _userService = service;
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
        
        [HttpPost]
        public ActionResult<User> Create([FromBody]User oUser)
        {
            return Ok(oUser);
        
        }
    }
}
