using System;
using System.Collections.Generic;
using System.Text;

namespace PinValidationData
{
    public class ValidationResults
    {
        public bool PIN_IsValid { get; set; }

        public bool Username_IsValid { get; set; }

        public List<string> Messages { get; set; } = new List<string>();
    }
}
