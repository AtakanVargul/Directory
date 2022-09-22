using Directory.Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace Directory.Identity.Infrastructure.Services
{
    public class PasswordValidatorServiceBase
    {

        public async Task<IdentityResult> ValidateAsync(UserManager<User> _userManager, User user, string password)
        {
            var requiredLength = _configuration.GetValue<int>("IdentitySettings:Password:RequiredLength");
            if (password.Length != requiredLength)
            {
                return IdentityResult.Failed(
                    new IdentityError
                    {
                        Code = "PasswordLengthError",
                        Description = $"Password must have {requiredLength} characters."
                    });
            }

            if (!int.TryParse(password, out _))
            {
                return IdentityResult.Failed(
                    new IdentityError
                    {
                        Code = "PasswordContentError",
                        Description = $"Password must contains only numbers."
                    });
            }

            var repetitiveRegexPattern = _configuration.GetValue<string>("PasswordValidation:RepetitiveRegexPattern");
            if (Regex.IsMatch(password, repetitiveRegexPattern))
            {
                return IdentityResult.Failed(
                      new IdentityError
                      {
                          Code = "PasswordRepetitiveCharacterError",
                          Description = $"Password can not have repetitive characters."
                      });
            }

            var successiveRegexPattern = _configuration.GetValue<string>("PasswordValidation:SuccessiveRegexPattern");
            if (Regex.IsMatch(password, successiveRegexPattern))
            {
                return IdentityResult.Failed(
                    new IdentityError
                    {
                        Code = "PasswordSuccessiveCharacterError",
                        Description = $"Password can not have successive characters."
                    });
            }

            return IdentityResult.Success;
        }
    }
}