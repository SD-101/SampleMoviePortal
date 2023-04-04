namespace SampleMoviePortal
{
    /// <summary>
    /// Movie Class
    /// </summary>
    public class Movie
    {
        public Movie()
        {

        }
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
    }
}