using Cinematic.DL.InMemoryDB;
using Cinematic.DL.Interfaces;
using Cinematic.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Cinematic.DL.Repo
{
    public class UserInMemoryRepository:IUserRepository
    {
        public UserInMemoryRepository()
        {

        }

        public User Create(User user)
        {
            UserInMemoryCollection.UsersDB.Add(user);

            return user;
        }



        public User Delete(int id)
        {
            var user = UserInMemoryCollection.UsersDB.FirstOrDefault(user => user.Id == id);

            UserInMemoryCollection.UsersDB.Remove(user);

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return UserInMemoryCollection.UsersDB;
        }

        public User GetById(int id)
        {
            return UserInMemoryCollection.UsersDB.FirstOrDefault(x => x.Id == id);
        }

        public User Update(User user)
        {
            var result = UserInMemoryCollection.UsersDB.FirstOrDefault(x => x.Id == user.Id);

            result.Username = user.Username;
            result.Amount = user.Amount;



            return result;
        }
    }
}
