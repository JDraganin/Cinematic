using AutoMapper;
using BarManager.Extensions;
using Castle.Core.Logging;
using Cinematic.BL.Interfaces;
using Cinematic.BL.Services;
using Cinematic.Controllers;
using Cinematic.DL.Interfaces;
using Cinematic.Models.DTO;
using Cinematic.Models.Requests;
using Cinematic.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Cinematic.Test
{
    public class MovieTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMovieRepository> _movieRepository;
        private readonly IMovieService _movieService;
        private readonly MovieController _movieController;

        private IList<Movie> Movies = new List<Movie>()
        {
              new Movie()
        {
             id=1,
             Name="Fast and furious 1",
             Genre="Äction",
             Rating=Models.Enums.Rating.Excellent,
             Duration=120,
             Price=5

            },
           new Movie()
        {
             id=2,
             Name="Matrix",
             Genre="Äction",
             Rating=Models.Enums.Rating.Average,
             Duration=110,
             Price=5.50

            },
        };

        public MovieTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _movieRepository = new Mock<IMovieRepository>();

            var logger = new Mock<ILogger>();

            _movieService = new MovieService(_movieRepository.Object);

            _movieController = new MovieController(_movieService, _mapper);
        }

      
        [Fact]
        public void Movie_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<IMovieService>();

            mockedService.Setup(x => x.GetAll()).Returns(Movies);

            //inject
            var controller = new MovieController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var movies = okObjectResult.Value as IEnumerable<Movie>;
            Assert.NotNull(movies);
            Assert.Equal(expectedCount, movies.Count());
        }

        [Fact]
        public void Movie_GetById_NameCheck()
        {
            //setup
            var movieId = 2;
            var expectedName = "Matrix";

            _movieRepository.Setup(x => x.GetById(movieId))
                .Returns(Movies.FirstOrDefault(m => m.id == movieId));

            //Act
            var result = _movieController.GetById(movieId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as MovieResponse;
            var movie = _mapper.Map<Movie>(response);

            Assert.NotNull(movie);
            Assert.Equal(expectedName, movie.Name);
        }

        [Fact]
        public void Movie_GetById_NotFound()
        {
            //setup
            var movieId = 3;

            _movieRepository.Setup(x => x.GetById(movieId))
                .Returns(Movies.FirstOrDefault(m => m.id == movieId));

            //Act
            var result = _movieController.GetById(movieId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(movieId, response);
        }

        [Fact]
        public void Movie_Update_MovieName()
        {
            var movieId = 1;
            var expectedName = "Updated Movie Name";

            var movie = Movies.FirstOrDefault(x => x.id == movieId);
            movie.Name = expectedName;

            _movieRepository.Setup(x => x.GetById(movieId))
                .Returns(Movies.FirstOrDefault(m => m.id == movieId));
            _movieRepository.Setup(x => x.Update(movie))
                .Returns(movie);

            //Act
            var movieUpdateRequest = _mapper.Map<Movie>(movie);
            var result = _movieController.Update(movieUpdateRequest);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Movie;
            Assert.NotNull(val);
            Assert.Equal(expectedName, val.Name);

        }

        [Fact]
        public void Movie_Delete_ExistingMovie()
        {
            //Setup
            var movieId = 1;

            var movie = Movies.FirstOrDefault(m => m.id == movieId);

            _movieRepository.Setup(x => x.Delete(movieId)).Callback(() => Movies.Remove(movie)).Returns(movie);

            //Act
            var result = _movieController.Delete(movieId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Movie;
            Assert.Equal(1, Movies.Count);
            Assert.Null(Movies.FirstOrDefault(m => m.id == movieId));
        }

        [Fact]
        public void Movie_Delete_NotExisting_Movie()
        {
            //Setup
            var movieId = 3;

            var movie = Movies.FirstOrDefault(x => x.id == movieId);

            _movieRepository.Setup(x => x.Delete(movieId)).Callback(() => Movies.Remove(movie)).Returns(movie);

            //Act
            var result = _movieController.Delete(movieId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(movieId, response);
        }

        [Fact]
        public void Movie_CreateMovie()
        {
            //setup
            var movie = new Movie()
            {
                Name = "Name 3",
                id = 3,
                Genre = "Comedy",
                Rating = Models.Enums.Rating.Average,
                Duration = 110,
                Price = 5.50
            };


            _movieRepository.Setup(x => x.GetAll()).Returns(Movies);

            _movieRepository.Setup(x => x.Create(It.IsAny<Movie>())).Callback(() =>
            {
                Movies.Add(movie);
            }).Returns(movie);

            //Act
            var result = _movieController.Create(_mapper.Map<MovieRequest>(movie));

            //Assert
            var okObjectResult = result as OkObjectResult;

            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.NotNull(Movies.FirstOrDefault(x => x.id == movie.id));
            Assert.Equal(3, Movies.Count);

        }

    }
}
