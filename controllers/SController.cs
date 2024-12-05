using AspStart.models;
using AspStart.services;
using Microsoft.AspNetCore.Mvc;

namespace AspStart.controllers
{
    [ApiController]
    [Route("user")]
    public class SController : ControllerBase
    {
        private readonly Service _service;
        public SController(Service service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_service.GetUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _service.GetUserById(id);
            if(user == null)
            {
                return NotFound("User not found!");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User request)
        {
            var createdUser = _service.CreateUser(request);
            return Ok(createdUser);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User request)
        {
            var user = _service.UpdateUser(id, request);
            if (user == null) return NotFound("User not found!");
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var deleteUser = _service.DeleteUser(id);
            if (!deleteUser) return NotFound("User Not Found!");
            return NoContent();
        }

    }
}
