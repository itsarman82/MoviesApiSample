using MoviesApiSample.Models.ActorNamespace;
using MoviesApiSample.Models.AuthorNamespace;

namespace MoviesApiSample.Models.MovieNamespace
{
    public class Movie  
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public ICollection<Actor> Actors{ get; set; }
    }
}