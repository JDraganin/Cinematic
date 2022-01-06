using Cinematic.DL.Interfaces;
using Cinematic.Models.Common;
using Cinematic.Models.DTO;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinematic.DL.Mongo
{
   public class UserMongoRepository:IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _userCollection = database.GetCollection<User>("Users");
        }

        public User Create(User user)
        {
            _userCollection.InsertOne(user);

            return user;
        }

        public User Update(User user)
            
        {
            _userCollection.ReplaceOne(userToReplace => userToReplace.Id == user.Id, user);
            return user;
        }

        public User Delete(int id)
        {
           var user = GetById(id);
            _userCollection.DeleteOne(User => User.Id == id);

            return user;
        }

        public User GetById(int id)
        {
            return _userCollection.Find(User => User.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return _userCollection.Find(User => true).ToList();
        }
    }
}

