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
        private readonly IConfiguration _configuration;

        public UtilityController(IAmazonSecretsManager secretsManager, IConfiguration configuration)
        {
            _secretsManager = secretsManager;
            _configuration = configuration;
        }

        [HttpGet("secret/{name}")]
        public async Task<IActionResult> GetSecret(string name)
        {
            var _secretsService = new SecretsService(_secretsManager);

            var secret = await _secretsService.GetSecretValueAsync(name);
            return Ok(secret);
        }
       



        [HttpGet("settings")]
        public IActionResult GetAllSettings()
        {
            var configData = new Dictionary<string, string>();

            foreach (var kvp in _configuration.AsEnumerable())
            {
                configData[kvp.Key] = kvp.Value;
            }

            return Ok(configData);
        }
    }
}
