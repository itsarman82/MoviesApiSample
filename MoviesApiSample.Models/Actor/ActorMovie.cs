using MoviesApiSample.Models.MovieNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiSample.Models.ActorNamespace
{
    public class ActorMovie
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public int MovieId { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
