using is_kino.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace is_kino.Service.Interface
{
    public interface IMovieService
    {
        public List<Movie> getAllMovies();
    }
}
