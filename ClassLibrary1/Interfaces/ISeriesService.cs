using Cinematic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinematic.BL.Interfaces
{
   public interface ISeriesService
    {
        IEnumerable<Series> GetByPrice(double price);
        Series GetByName(string name);
        IEnumerable<Series> GetByGenre(string genre);
        Series Create(Series series);

        Series Update(Series series);

        Series Delete(int id);

        Series GetById(int id);

        IEnumerable<Series> GetAll();
    }
}
