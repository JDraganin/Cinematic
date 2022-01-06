using Cinematic.DL.InMemoryDB;
using Cinematic.DL.Interfaces;
using Cinematic.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Cinematic.DL.Repo
{
   public class SeriesInMemoryRepository:ISeriesRepository
    {
        public SeriesInMemoryRepository()
        {

        }

        public Series Create(Series serie)
        {
            SeriesInMemoryCollection.SeriesDB.Add(serie);

            return serie;
        }



        public Series Delete(int id)
        {
            var series = SeriesInMemoryCollection.SeriesDB.FirstOrDefault(series => series.id == id);

            SeriesInMemoryCollection.SeriesDB.Remove(series);

            return series;
        }

        public IEnumerable<Series> GetAll()
        {
            return SeriesInMemoryCollection.SeriesDB;
        }

        public Series GetById(int id)
        {
            return SeriesInMemoryCollection.SeriesDB.FirstOrDefault(x => x.id == id);
        }

        public Series Update(Series series)
        {
            var result = SeriesInMemoryCollection.SeriesDB.FirstOrDefault(x => x.id == series.id);

            result.Name = series.Name;
            result.Genre = series.Genre;
            result.Price = series.Price;
            result.Rating = series.Rating;
            result.seasons = series.seasons;



            return result;
        }
    }
}
