namespace SampleMoviePortal
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Moview DB context
    /// </summary>
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        { }
        public DbSet<Movie> Movies { get; set; }

    }
}