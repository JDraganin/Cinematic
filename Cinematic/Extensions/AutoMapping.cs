using AutoMapper;
using Cinematic.Models.DTO;
using Cinematic.Models.Requests;
using Cinematic.Models.Responses;

namespace BarManager.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Movie, MovieResponse>().ReverseMap();
            CreateMap<MovieResponse, Movie>().ReverseMap();
            CreateMap<MovieRequest, Movie>().ReverseMap();

            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<UserResponse, User>().ReverseMap();
            CreateMap<UserResponse, User>().ReverseMap();

            CreateMap<Series, SeriesResponse>().ReverseMap();
            CreateMap<SeriesResponse, Series>().ReverseMap();
            CreateMap<SeriesRequest, Series>().ReverseMap();

        }
    }
}
