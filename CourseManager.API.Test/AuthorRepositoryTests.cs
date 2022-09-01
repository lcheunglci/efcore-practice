using CourseManager.API.DbContexts;
using CourseManager.API.Entities;
using CourseManager.API.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.API.Test
{
    public class AuthorRepositoryTests
    {
        [Fact]
        public void GetAuthors_PageSizeIsThree_ReturnsThreeAuthors()
        {
            // arrange
            var options = new DbContextOptionsBuilder<CourseContext>()
                .UseInMemoryDatabase($"CourseDatabaseForTesting{Guid.NewGuid()}")
                .Options;

            using (var context = new CourseContext(options))
            {
                context.Countries.Add(new Entities.Country()
                {
                    Id = "BE",
                    Description = "Belgium"
                });

                context.Countries.Add(new Entities.Country()
                {
                    Id = "US",
                    Description = "United States of America"
                });

                context.Authors.Add(new Entities.Author()
                {
                    FirstName = "Kevin",
                    LastName = "Smith",
                    CountryId = "BE"
                });
                context.Authors.Add(new Entities.Author()
                {
                    FirstName = "Kevin",
                    LastName = "Smith",
                    CountryId = "BE"
                });
                context.Authors.Add(new Entities.Author()
                {
                    FirstName = "Kevin",
                    LastName = "Smith",
                    CountryId = "BE"
                });
                context.Authors.Add(new Entities.Author()
                {
                    FirstName = "Gill",
                    LastName = "Carson",
                    CountryId = "BE"
                });
                context.Authors.Add(new Entities.Author()
                {
                    FirstName = "Julie",
                    LastName = "Lee",
                    CountryId = "US"
                });
                context.Authors.Add(new Entities.Author()
                {
                    FirstName = "Shawn",
                    LastName = "Wilder",
                    CountryId = "BE"
                });
                context.Authors.Add(new Entities.Author()
                {
                    FirstName = "Debbie",
                    LastName = "McKite",
                    CountryId = "US"
                });


                context.SaveChanges();
            }

            using (var context = new CourseContext(options))
            { 
                var authorRepository = new AuthorRepository(context);

                // Act
                var authors = authorRepository.GetAuthors(1, 3);

                // Assert
                Assert.Equal(3, authors.Count());
            }
        }

        [Fact]
        public void GetAuthor_EmptyGuid_ThrowsArgumentException()
        {
            // arrange
            //var options = new DbContextOptionsBuilder<CourseContext>()
            //    .UseInMemoryDatabase($"CourseDatabaseForTesting{Guid.NewGuid()}")
            //    .Options;
            var connectionStringBuilder =
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<CourseContext>()
                .UseSqlite(connection)
                .Options;

            using (var context = new CourseContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var authorRepository = new AuthorRepository(context);

                // assert
                Assert.Throws<ArgumentException>(
                    // act
                    () => authorRepository.GetAuthor(Guid.Empty));
            }
        }

        [Fact]
        public void AddAuthor_AuthorWithoutCountryId_AuthorHasBEAsCountryId()
        {
            // arrange
            var options = new DbContextOptionsBuilder<CourseContext>()
                .UseInMemoryDatabase($"CourseDatabaseForTesting{Guid.NewGuid()}")
                .Options;

            using (var context = new CourseContext(options))
            {
                context.Countries.Add(new Entities.Country()
                {
                    Id = "BE",
                    Description = "Belgium"
                });

                context.SaveChanges();
            }

            using (var context = new CourseContext(options))
            {

                var authorRepository = new AuthorRepository(context);
                var authorToAdd = new Author()
                {
                    FirstName = "Bob",
                    LastName = "Kevin",
                    Id = Guid.Parse("196A63E3-6F57-42C9-8B9D-BC487A379D16")
                };

                // act
                authorRepository.AddAuthor(authorToAdd);
                authorRepository.SaveChanges();
            }

            using (var context = new CourseContext(options))
            {
                // assert
                var authorRepository = new AuthorRepository(context);
                var addedAuthor = authorRepository.GetAuthor(
                   Guid.Parse("196A63E3-6F57-42C9-8B9D-BC487A379D16"));
                Assert.Equal("BE", addedAuthor.CountryId);
            }
        }

    }
}