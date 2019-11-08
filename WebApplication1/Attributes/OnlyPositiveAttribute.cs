using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Attributes
{
    public class OnlyPositiveAttribute : ValidationAttribute
    {
        private readonly string _message;
        public OnlyPositiveAttribute()
        {
            _message = null;
        }

        public OnlyPositiveAttribute(string message)
        {
            _message = message;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string text = (value as string).ToLower();
            if (text.Contains("bad"))
            {
                return new ValidationResult(_message != null ? _message : "No word 'bad' allowed here!");
            }
            return null;
        }
    }
}
