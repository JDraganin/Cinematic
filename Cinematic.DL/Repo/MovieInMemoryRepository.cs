using Cinematic.DL.InMemoryDB;
using Cinematic.DL.Interfaces;
using Cinematic.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Cinematic.DL.Repo
{
    public class MovieInMemoryRepository:IMovieRepository
    {
        public MovieInMemoryRepository()
        {

        }

        public Movie Create(Movie movie)
        {
            MovieInMemoryCollection.MovieDB.Add(movie);

            return movie;
        }



        public Movie Delete(int id)
        {
            var movie = MovieInMemoryCollection.MovieDB.FirstOrDefault(movie => movie.id == id);

            MovieInMemoryCollection.MovieDB.Remove(movie);

            return movie;
        }

        public IEnumerable<Movie> GetAll()
        {
            return MovieInMemoryCollection.MovieDB;
        }

        public Movie GetById(int id)
        {
            return MovieInMemoryCollection.MovieDB.FirstOrDefault(x => x.id == id);
        }

        public Movie Update(Movie movie)
        {
            var result = MovieInMemoryCollection.MovieDB.FirstOrDefault(x => x.id == movie.id);

            result.Name = movie.Name;
            result.Genre = movie.Genre;
            result.Price = movie.Price;
            result.Rating = movie.Rating;
          


            return result;
        }

    }
}
