using Cinematic.DL.Interfaces;
using Cinematic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinematic.BL.Interfaces
{
     public interface IUserService
    {
        User GetUserByID(int id);

        User GetUserByUsername(string name);

        IEnumerable<User> GetAll();

        string Buy(string username,string buyName);
        User Create(User user);

        User Update(User user);

        User Delete(int id);

        User GetById(int id);


    }
}
