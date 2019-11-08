using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required]
        public string Name { get; set; }
        [MinLength(5)]
        public string ShortDescription { get; set; }
        [Required]
        public int StudioId { get; set; }
        public Studio Studio { get; set; }
        [Required]
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
