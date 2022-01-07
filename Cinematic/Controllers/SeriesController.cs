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
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService _seriesService;
        private readonly IMapper _mapper;

        public SeriesController(ISeriesService sereisService, IMapper mapper)
        {
            _seriesService = sereisService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _seriesService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _seriesService.GetById(id);

            if (result == null) return NotFound(id);
            var response = _mapper.Map<SeriesResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] SeriesRequest serieRequest)
        {
            if (serieRequest == null) return BadRequest();

            var serie = _mapper.Map<Series>(serieRequest);

            var result = _seriesService.Create(serie);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);
            var SerieToRemove = _seriesService.GetById(id);

            var result = _seriesService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(SerieToRemove);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Series serie)
        {
            if (serie == null) return BadRequest();

            var searchBill = _seriesService.GetById(serie.id);

            if (searchBill == null) return NotFound(serie.id);

            var result = _seriesService.Update(serie);

            return Ok(result);
        }
        [HttpGet("GetByPrice")]
        public IActionResult GetByPrice(double price)
        {
            var result = _seriesService.GetByPrice(price);
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

            var result = _seriesService.GetByName(name);

            if (result == null) return NotFound(name);
            var response = _mapper.Map<MovieResponse>(result);

            return Ok(response);



        }
        [HttpGet("GetByGenre")]
        public IActionResult GetByGenre(string genre
            )
        {
            if (genre.Length <= 2) return BadRequest();

            var result = _seriesService.GetByGenre(genre);

            if (result == null) return NotFound(genre);


            return Ok(result);



        }

    }
}
