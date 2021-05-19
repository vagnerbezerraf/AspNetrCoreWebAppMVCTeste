using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetrCoreWebAppMVCTeste.Extensions
{
    public class ValidaIdadeValidationAttribute : ValidationAttribute
    {
        private readonly int _min;
        private readonly string _defaultErrorMessage = "";
        public ValidaIdadeValidationAttribute(int min, string defaultErrorMessage)
            : base(defaultErrorMessage)
        {
            _min = min;
            _defaultErrorMessage = defaultErrorMessage.Replace("{0}", _min.ToString());
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dtV = (DateTime)value;
            long lTicks = DateTime.Now.Ticks - dtV.Ticks;
            DateTime dtAge = new DateTime(lTicks);

            if (!(dtAge.Year >= _min && dtAge.Year <= 30))
            {
                return new ValidationResult(_defaultErrorMessage+_min);
            }
            return ValidationResult.Success;
        }

    }
}
