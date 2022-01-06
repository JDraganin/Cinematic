using AutoMapper;
using Cinematic.BL.Interfaces;
using Cinematic.Models.DTO;
using Cinematic.Models.Requests;
using Cinematic.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cinematic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _movieService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _movieService.GetById(id);

            if (result == null) return NotFound(id);
            var response = _mapper.Map<MovieResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateBill([FromBody] MovieRequest movieRequest)
        {
            if (movieRequest == null) return BadRequest();

            var movie = _mapper.Map<Movie>(movieRequest);

            var result = _movieService.Create(movie);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _movieService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Movie movie)
        {
            if (movie == null) return BadRequest();

            var searchBill = _movieService.GetById(movie.id);

            if (searchBill == null) return NotFound(movie.id);

            var result = _movieService.Update(movie);

            return Ok(result);
        }
        [HttpGet("GetByPrice")]
        public IActionResult GetByPrice(double price)
        {
            var result = _movieService.GetByPrice(price);
            if (result == null)
            {
                return NotFound(price);

            }
            return Ok(result);
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            if (name.Length <= 3) return BadRequest();

            var result = _movieService.GetByName(name);

            if (result == null) return NotFound(name);
            var response = _mapper.Map<MovieResponse>(result);

            return Ok(response);



        }
        [HttpGet("GetByGenre")]
        public IActionResult GetByGenre(string genre
            )
        {
            if (genre.Length <= 2) return BadRequest();

            var result = _movieService.GetByGenre(genre);

            if (result == null) return NotFound(genre);
            var response = _mapper.Map<MovieResponse>(result);

            return Ok(response);



        }

    }
}

