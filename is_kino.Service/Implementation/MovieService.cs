using is_kino.Domain.DomainModels;
using is_kino.Repository.Interface;
using is_kino.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace is_kino.Service.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public List<Movie> getAllMovies()
        {
            return this._movieRepository.GetAll().ToList();
        }
    }
}
