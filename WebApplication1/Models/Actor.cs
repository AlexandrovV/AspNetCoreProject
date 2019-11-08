using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        [Required]
        [Remote("CheckActorName", "Actors", ErrorMessage = "Vlad, you are not an actor, stop!")]
        public string Name { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
