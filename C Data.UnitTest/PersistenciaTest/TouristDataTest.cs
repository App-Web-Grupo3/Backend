using Data.Context;
using Data.Model;
using Data.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace C_Data.UnitTest.PersistenciaTest;

public class TouristDataTest
{
        private DbContextOptions<AppDbContext> GetDbOptions(string dbName)
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
        }

        [Fact]
        public async Task GetById_WhenTouristExists_ReturnsTourist()
        {
            // Arrange
            var options = GetDbOptions("GetById_DB");
            using (var context = new AppDbContext(options))
            {
                var touristData = new TouristData(context);
                var fakeTourist = new Tourist { Id = 1, Name = "John Doe", Phone = "123456789", IsActive = true };

                await context.Tourists.AddAsync(fakeTourist);
                await context.SaveChangesAsync();

                // Act
                var result = await touristData.GetById(fakeTourist.Id);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(fakeTourist.Id, result.Id);
                Assert.Equal(fakeTourist.Name, result.Name);
                Assert.Equal(fakeTourist.Phone, result.Phone);
            }
        }

        [Fact]
        public async Task GetByName_WhenTouristExists_ReturnsListOfTourists()
        {
            // Arrange
            var options = GetDbOptions("GetByName_DB");
            using (var context = new AppDbContext(options))
            {
                var touristData = new TouristData(context);
                var fakeTourist1 = new Tourist { Id = 1, Name = "John Doe", Phone = "123456789", IsActive = true };
                var fakeTourist2 = new Tourist { Id = 2, Name = "Jane Doe", Phone = "987654321", IsActive = true };

                await context.Tourists.AddRangeAsync(fakeTourist1, fakeTourist2);
                await context.SaveChangesAsync();

                // Act
                var result = await touristData.GetByName(new Tourist { Name = "Doe" });

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count);
            }
        }
        [Fact]
        public async Task GetAll_WhenTouristsExist_ReturnsListOfTourists()
        {
            // Arrange
            var options = GetDbOptions("GetAll_DB");
            using (var context = new AppDbContext(options))
            {
                var touristData = new TouristData(context);
                var fakeTourists = new List<Tourist>
                {
                    new Tourist { Id = 1, Name = "John Doe", Phone = "123456789", IsActive = true },
                    new Tourist { Id = 2, Name = "Jane Doe", Phone = "987654321", IsActive = true }
                };

                await context.Tourists.AddRangeAsync(fakeTourists);
                await context.SaveChangesAsync();

                // Act
                var result = await touristData.GetAll();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count);
            }
        }

        [Fact]
        public async Task GetByPhone_WhenTouristsExist_ReturnsListOfTourists()
        {
            // Arrange
            var options = GetDbOptions("GetByPhone_DB");
            using (var context = new AppDbContext(options))
            {
                var touristData = new TouristData(context);
                var fakeTourists = new List<Tourist>
                {
                    new Tourist { Id = 1, Name = "John Doe", Phone = "123456789", IsActive = true },
                    new Tourist { Id = 2, Name = "Jane Doe", Phone = "987654321", IsActive = true }
                };

                await context.Tourists.AddRangeAsync(fakeTourists);
                await context.SaveChangesAsync();

                // Act
                var result = await touristData.GetByPhone(new Tourist { Phone = "123456789" });

                // Assert
                Assert.NotNull(result);
                Assert.Single(result);
            }
        }
        [Fact]
        public async Task Create_ShouldReturnTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_database")
                .Options;
            var context = new AppDbContext(options);
            var touristData = new TouristData(context);

            var tourist = new Tourist
            {
                Name = "John",
                LastName = "Doe",
                Mail = "john@example.com",
                Password = "password",
                Phone = "123456789",
                IsActive = true
            };

            // Act
            var result = await touristData.Create(tourist);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Update_ShouldReturnTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_database")
                .Options;
            var context = new AppDbContext(options);
            var touristData = new TouristData(context);

            var tourist = new Tourist
            {
                Name = "John",
                LastName = "Doe",
                Mail = "john@example.com",
                Password = "password",
                Phone = "123456789",
                IsActive = true
            };

            // Act
            var result = await touristData.Update(tourist, 1); // Assuming the ID to be 1

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_database")
                .Options;
            var context = new AppDbContext(options);
            var touristData = new TouristData(context);

            var tourist = new Tourist
            {
                Name = "John",
                LastName = "Doe",
                Mail = "john@example.com",
                Password = "password",
                Phone = "123456789",
                IsActive = true
            };
            context.Tourists.Add(tourist);
            context.SaveChanges();

            // Act
            var result = await touristData.Delete(1); // Assuming the ID to be 1

            // Assert
            Assert.True(result);
        }
}