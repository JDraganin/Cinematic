using Cinematic.BL.Interfaces;
using Cinematic.DL.Interfaces;
using Cinematic.Models.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinematic.BL.Services
{
    public class SeriesService : ISeriesService
    {
        public readonly ISeriesRepository _serieRepository;
        private readonly ILogger _logger;

        public SeriesService(ISeriesRepository serieRepository, ILogger logger)

        {

            _serieRepository = serieRepository;
            _logger = logger;
        }

        public IEnumerable<Series> GetByGenre(string genre)
        {
            var result = _serieRepository.GetAll().Where(x => x.Genre == genre);

            return result;

        }

        public Series GetByName(string name)
        {

            try
            {
                return _serieRepository.GetAll().FirstOrDefault(x => x.Name == name);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return _serieRepository.GetAll().FirstOrDefault(x => x.Name == name);


        }

        public IEnumerable<Series> GetByPrice(double price)
        {
            var result = _serieRepository.GetAll().Where(x => x.Price <= price);

            return result;
        }
        public Series Create(Series serie)

        {
            try
            {
                var index = _serieRepository.GetAll().OrderByDescending(x => x.id).FirstOrDefault()?.id;

                serie.id = (int)(index != null ? index + 1 : 1);

                return _serieRepository.Create(serie);
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
            }

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
            try
            {
                return _serieRepository.GetAll();
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
            }
            return _serieRepository.GetAll();
        }
    }
}
