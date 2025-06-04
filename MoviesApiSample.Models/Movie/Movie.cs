using MoviesApiSample.Models.ActorNamespace;
using MoviesApiSample.Models.DirectorNamespace;

namespace MoviesApiSample.Models.MovieNamespace
{
    public class Movie  
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Director director { get; set; }
        public ICollection<Actor> actors { get; set; }
    }
}