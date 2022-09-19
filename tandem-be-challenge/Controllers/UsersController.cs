using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using tandem_be_challenge.DTOs;
using tandem_be_challenge.Exceptions;
using tandem_be_challenge.Services;

namespace tandem_be_challenge.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserResponseDTO))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestDTO usersDTO)
        {
            try
            {
                UserResponseDTO response = await usersService.CreateUser(usersDTO);
                return Created("/api/users", response);
            }
            catch (Exception ex)
            {
                if (ex is UserAlreadyExistsException)
                {
                    return Conflict(ex.Message);
                }

                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetUserByEmailAddress([Required][FromQuery] string emailAddress)
        {
            try
            {
                UserResponseDTO response = await usersService.GetUserByEmailAddress(emailAddress);
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex is UserNotFoundException)
                {
                    return NotFound(ex.Message);
                }

                return Problem(ex.Message);
            }
        }
    }
}
