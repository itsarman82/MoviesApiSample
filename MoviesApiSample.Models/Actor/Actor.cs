using MoviesApiSample.Models.MovieNamespace;

namespace MoviesApiSample.Models.ActorNamespace
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; } 
        public int Age { get; set; }
        public int ActorMovieId { get; set; }
        public ActorMovie ActorMovie { get; set; }
    }
}
