using Cinematic.Models.DTO;
using System.Collections.Generic;

namespace Cinematic.DL.InMemoryDB
{
    public class UserInMemoryCollection
    {
        public static List<User> UsersDB = new List<User>
        {
            new User()
            {
                Id=1,
                Username="test1",
                Amount=20,

            },
              new User()
            {
                Id=2,
                Username="test2",
                Amount=10,

            },
                new User()
            {
                Id=3,
                Username="test3",
                Amount=30,

            },

        };
    }
}
