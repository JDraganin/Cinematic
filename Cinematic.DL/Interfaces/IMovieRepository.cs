
using Cinematic.Models.DTO;
using System.Collections.Generic;

namespace Cinematic.DL.Interfaces
{
    public interface IMovieRepository
    {
        Movie Create(Movie movie);

        Movie Update(Movie movie);

        Movie Delete(int id);

        Movie GetById(int id);

        IEnumerable<Movie> GetAll();
    }
}

