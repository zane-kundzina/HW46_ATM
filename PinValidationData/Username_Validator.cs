using System;
using System.Collections.Generic;
using System.Text;

namespace PinValidationData
{
    public class Username_Validator
    {
        public static ValidationResults ValidateUsername(string username1, string username2)
        {
            var length = Validate_Username_Length(username1);
            var match = Validate_Username_Match(username1, username2);

            var validationResult = new ValidationResults();

            validationResult.Username_IsValid = length.Username_IsValid && match.Username_IsValid;

            if (!length.Username_IsValid)
            {
                validationResult.Messages.Add(length.Message);
            }

            if (!match.Username_IsValid)
            {
                validationResult.Messages.Add(match.Message);
            }

            return validationResult;
        }

        private static ValidationResult Validate_Username_Length(string username)
        {
            const int length = 4;

            if (username.Length < length)
            {
                return new ValidationResult { Username_IsValid = false, Message = $"Username have to be at least {length} digits/characters long!" };
            }

            return new ValidationResult { Username_IsValid = true };
        }

        private static ValidationResult Validate_Username_Match(string username1, string username2)
        {
            if (username1 != username2)
            {
                return new ValidationResult { Username_IsValid = false, Message = $"Usernames do not match!" };
            }

            return new ValidationResult { Username_IsValid = true };
        }
    }
}
