using Cinematic.BL.Interfaces;
using Cinematic.DL.Interfaces;
using Cinematic.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Cinematic.BL.Services
{
    public  class SeriesService:ISeriesService
    {
        public readonly ISeriesRepository _serieRepository;

        public SeriesService(ISeriesRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }

        public IEnumerable<Series> GetByGenre(string genre)
        {
            var result = _serieRepository.GetAll().Where(x => x.Genre == genre);

            return result;

        }

        public Series GetByName(string name)
        {
            var result = _serieRepository.GetAll().FirstOrDefault(x => x.Name == name);

            return result;
        }

        public IEnumerable<Series> GetByPrice(double price)
        {
            var result = _serieRepository.GetAll().Where(x => x.Price <= price);

            return result;
        }
        public Series Create(Series serie)
        {
            var index = _serieRepository.GetAll().OrderByDescending(x => x.id).FirstOrDefault()?.id;

            serie.id = (int)(index != null ? index + 1 : 1);

            return _serieRepository.Create(serie);
        }

        public Series Update(Series series)
        {
            return _serieRepository.Update(series);
        }

        public Series Delete(int id)
        {
            return _serieRepository.Delete(id);
        }

        public Series GetById(int id)
        {
            return _serieRepository.GetById(id);
        }

        public IEnumerable<Series> GetAll()
        {
            return _serieRepository.GetAll();
        }
    }
}
