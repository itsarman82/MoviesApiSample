namespace MoviesApiSample.Models.DirectorNamespace
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int DirectorMovieId { get; set; }
        public DirectorMovie DirectorMovie { get; set; }
    }
}
