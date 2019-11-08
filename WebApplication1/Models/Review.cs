using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Attributes;

namespace WebApplication1.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Required]
        [OnlyPositive("Maybe you still liked the movie?")]
        public string Text { get; set; }
        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [Required]
        public int ReviewerId { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}
