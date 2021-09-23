using Microsoft.Extensions.Configuration;
using System;

namespace Infra.ApplicationServices.Utility
{
    public static class TokenSecretExtractor
    {
        public static string Extract(IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new Exception("configuration can NOT be null.");
            }

            return configuration.GetSection("Secret").Value;
        }
    }
}
