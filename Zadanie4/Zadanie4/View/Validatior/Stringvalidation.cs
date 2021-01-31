using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace View.Validatior
{
    public class Stringvalidation : ValidationRule
    {
        public int mini { get; set; }
        public int maxy { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = ((string)value);
            if (s.Length >= mini && s.Length <= maxy)
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, $"Validation Error");
            }
        }
    }
}
