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
        private readonly ILogger logger;

        public UsersController(IUsersService usersService, ILogger<UsersController> logger)
        {
            this.usersService = usersService;
            this.logger = logger;
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserResponseDTO))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestDTO usersDTO)
        {
            try
            {
                logger.LogInformation("Started creating {0} user", usersDTO.EmailAddress);

                UserResponseDTO response = await usersService.CreateUser(usersDTO);

                logger.LogInformation("Created {0} user", usersDTO.EmailAddress);
                return Created("/api/users", response);
            }
            catch (Exception ex)
            {
                if (ex is UserAlreadyExistsException)
                {
                    logger.LogError("User creation failed with User already exists exception: {0}", usersDTO.EmailAddress);
                    return Conflict(ex.Message);
                }

                logger.LogError("User creation failed: {0}", usersDTO.EmailAddress);
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetUserByEmailAddress([Required][FromQuery] string emailAddress)
        {
            try
            {
                logger.LogInformation("Started getting {0} user information", emailAddress);

                UserResponseDTO response = await usersService.GetUserByEmailAddress(emailAddress);

                logger.LogInformation("Got {0} user information", emailAddress);
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex is UserNotFoundException)
                {
                    logger.LogError("{0} User not found", emailAddress);
                    return NotFound(ex.Message);
                }

                logger.LogError("Error while getting user information for {0}", emailAddress);
                return Problem(ex.Message);
            }
        }
    }
}
