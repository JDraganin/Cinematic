using Cinematic.BL.Interfaces;
using Cinematic.DL.Interfaces;
using Cinematic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinematic.BL.Services
{

    public class MovieService : IMovieService
    {
       public readonly  IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> GetByGenre(string genre)
        {
            var result = _movieRepository.GetAll().Where(x=>x.Genre == genre);

            return result;

        }

        public Movie GetByName(string name)
        {
            var result = _movieRepository.GetAll().FirstOrDefault(x => x.Name == name);

            return result;
        }

        public IEnumerable<Movie> GetByPrice(double price)
        {
            var result = _movieRepository.GetAll().Where(x => x.Price <= price);

            return result;
        }
        public Movie Create(Movie movie)
        {
            var index = _movieRepository.GetAll().OrderByDescending(x => x.id).FirstOrDefault()?.id;

            movie.id = (int)(index != null ? index + 1 : 1);

            return _movieRepository.Create(movie);
        }

        public Movie Update(Movie movie)
        {
            return _movieRepository.Update(movie);
        }

        public Movie Delete(int id)
        {
            return _movieRepository.Delete(id);
        }

        public Movie GetById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }


    }
  


    }


