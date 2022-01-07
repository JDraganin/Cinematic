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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _userService.GetById(id);

            if (result == null) return NotFound(id);
            var response = _mapper.Map<UserResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] UserRequest userRequest)
        {
            if (userRequest == null) return BadRequest();

            var user = _mapper.Map<User>(userRequest);

            var result = _userService.Create(user);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var userToDelete = _userService.GetById(id);

            var result = _userService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(userToDelete);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null) return BadRequest();

            var searchBill = _userService.GetById(user.Id);

            if (searchBill == null) return NotFound(user.Id);

            var result = _userService.Update(user);

            return Ok(result);
        }
        [HttpPost("Buy")]
        public IActionResult Buy(string username, string buyName)
        {
            var result = _userService.Buy(username, buyName);

            return Ok(result);
        }
        [HttpGet("GetUserByUsername")]
        public IActionResult GetUserByUsername(string name)
        {
            if (name.Length <= 3) return BadRequest();

            var result = _userService.GetUserByUsername(name);

            if (result == null) return NotFound(name);
            var response = _mapper.Map<UserResponse>(result);

            return Ok(response);



        }

    }
}