using System;
using System.Collections.Generic;
using System.Text;

namespace PinValidationData
{
    public class ValidationResult
    {
        public bool PIN_IsValid { get; set; }

        public bool Username_IsValid { get; set; }

        public string Message { get; set; }
    }
}
