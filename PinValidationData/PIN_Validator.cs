using System;

namespace PinValidationData
{
    public class PIN_Validator
    {
        public static ValidationResults ValidatePIN(string pin1, string pin2)
        {
            var length = Validate_PIN_Length(pin1);
            var match = Validate_PIN_Match(pin1, pin2);

            var validationResult = new ValidationResults();

            validationResult.PIN_IsValid = length.PIN_IsValid && match.PIN_IsValid;

            if (!length.PIN_IsValid)
            {
                validationResult.Messages.Add(length.Message);
            }

            if (!match.PIN_IsValid)
            {
                validationResult.Messages.Add(match.Message);
            }

            return validationResult;
        }

        private static ValidationResult Validate_PIN_Length (string pin)
        {
            const int length = 6;

            if (pin.Length != length)
            {
                return new ValidationResult { PIN_IsValid = false, Message = $"PIN have to be {length} digits long!" };
            }

            return new ValidationResult { PIN_IsValid = true };
        }

        private static ValidationResult Validate_PIN_Match (string pin1, string pin2)
        {
            if(pin1 != pin2)
            {
                return new ValidationResult { PIN_IsValid = false, Message = $"PINs do not match!" };
            }

            return new ValidationResult { PIN_IsValid = true };
        }
    }
}
