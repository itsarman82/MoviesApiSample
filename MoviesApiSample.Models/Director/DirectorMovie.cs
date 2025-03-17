using MoviesApiSample.Models.MovieNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiSample.Models.DirectorNamespace
{
    public class DirectorMovie
    {
        public int Id { get; set; }
        [ForeignKey("Director")]
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
