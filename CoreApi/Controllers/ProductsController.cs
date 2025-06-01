using Contract;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IService<User> _userService;

    public ProductsController(IService<User> service)
    {
        _userService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        User oUser = _userService.RetrieveById(1);
       
        
        return Ok(new[] { oUser.Email, oUser.UserName });
    }
}
