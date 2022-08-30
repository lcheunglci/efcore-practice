using CourseManager.API.DbContexts;
using CourseManager.API.Services;
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
                .UseInMemoryDatabase("CourseDatabaseForTesting")
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

                var authorRepository = new AuthorRepository(context);

                // Act
                var authors = authorRepository.GetAuthors(1, 3);

                // Assert
                Assert.Equal(3, authors.Count());
            }




            // assert
        }
    }
}