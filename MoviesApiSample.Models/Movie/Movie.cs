using MoviesApiSample.Models.ActorNamespace;
using MoviesApiSample.Models.DirectorNamespace;

namespace MoviesApiSample.Models.MovieNamespace
{
    public class Movie  
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DirectorMovieId { get; set; }
        public DirectorMovie DirectorMovie { get; set; }
        public int ActorMovieId { get; set; }
        public ActorMovie ActorMovie { get; set; }
    }
}