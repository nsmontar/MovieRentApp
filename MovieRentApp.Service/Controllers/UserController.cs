using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieRentApp.Dal.Repos.Interfaces;
using MovieRentApp.Models.Entities;

namespace MovieRentApp.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repo;

        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     GET /api/User
        /// </remarks>
        /// <returns>List of all users</returns>
        /// <response code="200">Returns users.</response>
        /// <response code="500">Returned when there was an error in the repo.</response>
        [HttpGet(Name="GetAllUsers")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IList<User>> Get()
        {
            IEnumerable<User> users = _repo.GetAll().ToList();
            return Ok(users);
        }

        /// <summary>
        /// Gets a single user.
        /// </summary>
        /// <param name="id">Primary Key of the user to retrieve</param>
        /// <remarks>
        /// Sample request:
        ///     GET /api/Users/5
        /// </remarks>
        /// <returns>Single User</returns>
        /// <response code="200">Returns single user.</response>
        /// <response code="404">Returned when user with specific id doesn't exist.</response>
        /// <response code="500">Returned when there was an error in the repo.</response>
        [HttpGet("{id}",Name = "GetUser")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<User> Get(int id)
        {
            User item = _repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Gets all rentals for a single user.
        /// </summary>
        /// <param name="UserId">Primary Key of the user to retrieve</param>
        /// <remarks>
        /// Sample request:
        ///     GET /api/Users/5/rentals
        /// </remarks>
        /// <returns>List of all rentals for a single user</returns>
        /// <response code="200">Returns all rentals for a single user.</response>
        /// <response code="500">Returned when there was an error in the repo.</response>
        [HttpGet("{UserId}/rentals", Name="GetUserRentals")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IList<Rental>> GetRentalsForUser([FromServices] IRentalRepo rentalRepo, int UserId) 
            => rentalRepo.GetRentalsForUser(UserId).ToList();
    }        

}