using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.Extensions.Logging;

namespace IdS4
{
    internal class CustomSecretValidator : ISecretValidator
    {
        private readonly ILogger<CustomSecretValidator> _logger;

        public CustomSecretValidator(ILogger<CustomSecretValidator> logger)
        {
            _logger = logger;
        }

        public Task<SecretValidationResult> ValidateAsync(IEnumerable<Secret> secrets, ParsedSecret parsedSecret)
        {
            var given = parsedSecret.Credential as string;

            _logger.LogDebug($"Parsed secret: {given}");

            if (secrets.Any(a => a.Value == given.Sha256()))
            {
                return Task.FromResult(new SecretValidationResult { Success = true });
            }

            return Task.FromResult(new SecretValidationResult { Success = false });
        }
    }
}