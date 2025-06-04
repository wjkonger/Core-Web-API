using Amazon.SecretsManager;
using CoreApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
       private readonly IAmazonSecretsManager _secretsManager;

        public UtilityController(IAmazonSecretsManager secretsManager)
        {
            _secretsManager = secretsManager;
        }

        [HttpGet("secret/{name}")]
        public async Task<IActionResult> GetSecret(string name)
        {
            var _secretsService = new SecretsService(_secretsManager);

            var secret = await _secretsService.GetSecretValueAsync(name);
            return Ok(secret);
        }
        
        
    }
}
