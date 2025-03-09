using MoviesApiSample.Models.MovieNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiSample.Models.DirectorNamespace
{
    public class DirectorMovie
    {
        public int Id { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public int MovieId { get; set; }
        public ICollection<Movie> Movies { get; set; }

    }
}
