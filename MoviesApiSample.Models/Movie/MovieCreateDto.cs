using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiSample.Models.MovieNamespace
{
    public class MovieCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int DirectorId { get; set; }
        public List<int> ActorIds { get; set; }
    }
}

public class MovieUpdateDto
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int DirectorId { get; set; }
    [Required]
    public List<int> ActorIds { get; set; }
}

