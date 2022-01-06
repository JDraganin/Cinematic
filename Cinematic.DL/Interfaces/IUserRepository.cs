using Cinematic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinematic.DL.Interfaces
{
  public  interface IUserRepository
    {
        User Create(User user);

        User Update(User user);

        User Delete(int id);

        User GetById(int id);

        IEnumerable<User> GetAll();
    }
}