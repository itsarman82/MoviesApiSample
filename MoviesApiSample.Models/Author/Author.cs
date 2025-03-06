using MoviesApiSample.Models.MovieNamespace;

namespace MoviesApiSample.Models.AuthorNamespace
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
