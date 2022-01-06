using Cinematic.DL.Interfaces;
using Cinematic.Models.Common;
using Cinematic.Models.DTO;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Cinematic.DL.Mongo
{
   public class MovieMongoRepository:IMovieRepository
    {
        private readonly IMongoCollection<Movie> _movieCollection;

        public MovieMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _movieCollection = database.GetCollection<Movie>("Movies");
        }

        public Movie Create(Movie movie)
        {
            _movieCollection.InsertOne(movie);

            return movie;
        }

        public Movie Update(Movie movie)
        {
            _movieCollection.ReplaceOne(movieToReplace => movieToReplace.id == movie.id, movie);
            return movie;
        }

        public Movie Delete(int id)
        {
            var movie = GetById(id);
            _movieCollection.DeleteOne(Movie => Movie.id == id);

            return movie;
        }

        public Movie GetById(int id)
        {
            return _movieCollection.Find(Movie => Movie.id == id).FirstOrDefault();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movieCollection.Find(Movie => true).ToList();
        }
    }
}

