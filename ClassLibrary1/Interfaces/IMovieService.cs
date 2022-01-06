using Cinematic.Models.DTO;
using System.Collections.Generic;

namespace Cinematic.BL.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetByPrice(double price);
        Movie GetByName(string name);
        IEnumerable<Movie> GetByGenre(string genre);
        Movie Create(Movie movie);

        Movie Update(Movie movie);

        Movie Delete(int id);

        Movie GetById(int id);

        IEnumerable<Movie> GetAll();


    }
}
