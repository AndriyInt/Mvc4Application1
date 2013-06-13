namespace Mvc4Application1.Models
{
    using System.Data.Entity;

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        ////public MovieDBContext()
        ////    : base("BloggingDatabase") // Creates file with specified name (LocalDB)
        ////{
        ////}
        
        public MovieDBContext()
            : base("DefaultConnection")
        {
        }
    }
}