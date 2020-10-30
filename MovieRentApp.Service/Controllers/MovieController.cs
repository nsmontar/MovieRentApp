using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieRentApp.Dal.Repos.Interfaces;
using MovieRentApp.Models.Entities;

namespace MovieRentApp.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepo _repo;

        public MovieController(IMovieRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get all movies.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     GET /api/Movie
        /// </remarks>
        /// <returns>List of all movies</returns>
        /// <response code="200">Returns movies.</response>
        /// <response code="500">Returned when there was an error in the repo.</response>
        [HttpGet(Name="GetAllMovies")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IList<Movie>> Get()
        {
            IEnumerable<Movie> movies = _repo.GetAll().ToList();
            return Ok(movies);
        }

        /// <summary>
        /// Gets a single movie.
        /// </summary>
        /// <param name="id">Primary Key of the movie to retrieve</param>
        /// <remarks>
        /// Sample request:
        ///     GET /api/Movie/5
        /// </remarks>
        /// <returns>Single Movie</returns>
        /// <response code="200">Returns single Movie.</response>
        /// <response code="404">Returned when Movie with specific id doesn't exist.</response>
        /// <response code="500">Returned when there was an error in the repo.</response>
        [HttpGet("{id}",Name = "GetMovie")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<Movie> Get(int id)
        {
            Movie item = _repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Gets all rentals for a single movie.
        /// </summary>
        /// <param name="movieId">Primary Key of the movie to retrieve</param>
        /// <remarks>
        /// Sample request:
        ///     GET /api/Movie/5/rentals
        /// </remarks>
        /// <returns>List of all rentals of a movie</returns>
        /// <response code="200">Returns all rentals of a single movie.</response>
        /// <response code="500">Returned when there was an error in the repo.</response>
        [HttpGet("{movieId}/rentals", Name="GetMovieRentals")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IList<Rental>> GetRentalsForMovie([FromServices] IRentalRepo rentalRepo, int movieId) 
            => rentalRepo.GetRentalsForMovie(movieId).ToList();
    }        

}