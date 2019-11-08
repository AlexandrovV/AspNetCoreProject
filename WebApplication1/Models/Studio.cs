using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Studio : IValidatableObject
    {
        public int StudioId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            string name = Name.ToLower();
            if (name == "netflix" || name == "hbo")
            {
                errors.Add(new ValidationResult("Our website is about movies, not series!"));
            }
            return errors;
        }
    }
}
