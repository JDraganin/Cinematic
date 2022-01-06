using Cinematic.DL.Interfaces;
using Cinematic.Models.Common;
using Cinematic.Models.DTO;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Cinematic.DL.Mongo
{
   public class SeriesMongoRepository:ISeriesRepository
    {
        private readonly IMongoCollection<Series> _seriesCollection;

        public SeriesMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _seriesCollection = database.GetCollection<Series>("Series");
        }

        public Series Create(Series serie)
        {
            _seriesCollection.InsertOne(serie);

            return serie;
        }

        public Series Update(Series series)
        {
            _seriesCollection.ReplaceOne(serieToReplace => serieToReplace.id == series.id, series);
            return series;
        }

        public Series Delete(int id)
        {
            var serie = GetById(id);
            _seriesCollection.DeleteOne(Series => Series.id == id);

            return serie;
        }

        public Series GetById(int id)
        {
            return _seriesCollection.Find(Series => Series.id == id).FirstOrDefault();
        }

        public IEnumerable<Series> GetAll()
        {
            return _seriesCollection.Find(Series => true).ToList();
        }
    }
}

