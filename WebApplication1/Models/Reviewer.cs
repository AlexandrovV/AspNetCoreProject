using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Reviewer
    {
        public int ReviewerId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
