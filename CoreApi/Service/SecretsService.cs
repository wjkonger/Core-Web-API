using System;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace CoreApi.Service;

public class SecretsService
{
    private readonly IAmazonSecretsManager _secretsManager;

    public SecretsService(IAmazonSecretsManager secretsManager)
    {
       _secretsManager = secretsManager;
    }

    public async Task<string> GetSecretValueAsync(string secretName)
    {
        var request = new Amazon.SecretsManager.Model.GetSecretValueRequest
        {
            SecretId = secretName
        };
        var response = await _secretsManager.GetSecretValueAsync(request);
        return response.SecretString;
    }
}
