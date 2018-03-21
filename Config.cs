using System.Collections.Generic;

using IdentityServer4.Models;

namespace IdS4
{
    internal class Config
    {
        internal static string Api => "api";

        public static IEnumerable<ApiResource> GetApiResources()
        {
            yield return new ApiResource(Api, "My API");
        }

        public static IEnumerable<Client> GetClients()
        {
            yield return new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("1+1".Sha256())},
                AllowedScopes = {Api}
            };
        }
    }
}