using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;

namespace SampleMoviePortal.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly MovieContext _movieContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MovieController(ILogger<MovieController> logger, MovieContext context)
        {
            _logger = logger;
            _movieContext = context ?? throw new ArgumentNullException(nameof(context));

            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetMovies")]
        [ProducesResponseType(typeof(IEnumerable<Movie>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(string genre)
        {

            if (!string.IsNullOrWhiteSpace(genre))
            {
                var response = await GetMoviesAsync(genre);

                if (!response.Any())
                {
                    return BadRequest("Movie/s for this genre does not exists.");
                }

                return Ok(response);
            }

            return BadRequest("Genre value invalid.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        private async Task<IEnumerable<Movie>> GetMoviesAsync(string genre)
        {
            return _movieContext.Movies.Where(m => !string.IsNullOrEmpty(m.Genre) && m.Genre.ToLower() == genre.ToLower()).ToList();
        }

    }
}