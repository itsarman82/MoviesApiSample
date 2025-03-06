using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiSample.DAL.Framework
{
    
    class MoviesApiSampleRepository
    {
        private readonly MoviesApiSampleDbContex _ctx;
        public MoviesApiSampleRepository(MoviesApiSampleDbContex ctx)
        {
            _ctx = ctx;
        }

        //TODO: Write Queries
    }
}
