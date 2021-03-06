namespace Andriy.Mvc4Application1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using Andriy.Mvc4Application1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Mvc4Application1.Models.MovieDBContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Mvc4Application1.Models.MovieDBContext context)
        {
            // This method will be called after migrating to the latest version.
            context.Movies.AddOrUpdate(
                i => i.Title,
                new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-1-11"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "G",
                    },
                new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "PG",
                    },
                new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "PG",
                    },
                new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "G",
                    });
        }
    }
}
