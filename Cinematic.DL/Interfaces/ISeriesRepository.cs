using Cinematic.Models.DTO;
using System.Collections.Generic;


namespace Cinematic.DL.Interfaces
{
    public interface ISeriesRepository
    {
        Series Create(Series series);

        Series Update(Series series);

        Series Delete(int id);

        Series GetById(int id);

        IEnumerable<Series> GetAll();
    }
}
