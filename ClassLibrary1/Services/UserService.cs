using Cinematic.BL.Interfaces;
using Cinematic.DL.Interfaces;
using Cinematic.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Cinematic.BL.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        public readonly ISeriesRepository _serieRepository;
        public readonly IMovieRepository _movieRepository;


        public UserService(IUserRepository userRepository, ISeriesRepository seriesRepository, IMovieRepository movieRepository)
        {
            _userRepository = userRepository;
            _serieRepository = seriesRepository;
            _movieRepository = movieRepository;


        }

        public User Create(User user)
        {
            var index = _userRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            user.Id = (int)(index != null ? index + 1 : 1);

            return _userRepository.Create(user);
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

        public User Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetUserByID(int id)
        {
            var result = _userRepository.GetAll().FirstOrDefault(x => x.Id == id);

            return result;
        }

        public User GetUserByUsername(string name)
        {
            var result = _userRepository.GetAll().FirstOrDefault(x => x.Username == name);

            return result;
        }



        public string Buy(string username, string buyName)
        {
            var user = GetUserByUsername(username);
            Movie movieToBuy = null;
            Series serieToBuy = null;

            var movies = _movieRepository.GetAll();
            foreach (var movie in movies)
            {
                if (movie.Name == buyName)
                {
                    movieToBuy = movie;
                    break;
                }
            }
            var series = _serieRepository.GetAll();
            foreach (var serie in series)
            {
                if (serie.Name == buyName)
                {
                    serieToBuy = serie;
                    break;
                }
            }
            if (movieToBuy != null)
            {
                if (user.Amount >= movieToBuy.Price)
                {
                    return string.Format("User {0} buy {1}", user, movieToBuy);
                }
                else
                {
                    return "Not enough money";
                }

            }

            if (serieToBuy != null)
            {
                if (user.Amount >= serieToBuy.Price)
                {
                    return string.Format("User {0} buy {1}", user, serieToBuy);
                }
                else
                {
                    return "Not enough money";
                }

            }
            return "Not Found";

        }
    }

}

