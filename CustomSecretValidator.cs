using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace IdS4
{
    internal class CustomSecretValidator : ISecretValidator
    {
        public Task<SecretValidationResult> ValidateAsync(IEnumerable<Secret> secrets, ParsedSecret parsedSecret)
        {
            var given = parsedSecret.Credential as string;
            if (secrets.Any(a => a.Value == given.Sha256()))
            {
                return Task.FromResult(new SecretValidationResult { Success = true });
            }

            return Task.FromResult(new SecretValidationResult { Success = false });
        }
    }
}