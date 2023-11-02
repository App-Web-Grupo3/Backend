using Data.Context;
using Data.Model;
using Data.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace C_Data.UnitTest.PersistenciaTest;

public class FavoritesDataTest
{
    private DbContextOptions<AppDbContext> GetDbOptions(string dbName)
    {
        return new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;
    }

    [Fact]
    public async Task GetById_WhenFavoritesExists_ShouldReturnFavorites()
    {
        // Arrange
        var options = GetDbOptions("GetById_DB");
        using (var context = new AppDbContext(options))
        {
            var favoritesData = new FavoritesData(context);
            var fakeFavorites = new Favorites { Id = 1, TouristId = 1, ActivitiesId = 1, IsActive = true };

            await context.Favorites.AddAsync(fakeFavorites);
            await context.SaveChangesAsync();

            // Act
            var result = await favoritesData.GetById(fakeFavorites.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(fakeFavorites.Id, result.Id);
            Assert.Equal(fakeFavorites.TouristId, result.TouristId);
            Assert.Equal(fakeFavorites.ActivitiesId, result.ActivitiesId);
        }
    }

    [Fact]
    public async Task GetById_WhenFavoritesDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        var options = GetDbOptions("GetById_DB_NotExist");
        using (var context = new AppDbContext(options))
        {
            var favoritesData = new FavoritesData(context);
            var fakeFavorites = new Favorites { Id = 1, TouristId = 1, ActivitiesId = 1, IsActive = true };

            // Act
            var result = await favoritesData.GetById(fakeFavorites.Id);

            // Assert
            Assert.Null(result);
        }
    }

    [Fact]
    public async Task GetAll_WhenFavoritesExist_ShouldReturnListOfFavorites()
    {
        // Arrange
        var options = GetDbOptions("GetAll_DB");
        using (var context = new AppDbContext(options))
        {
            var favoritesData = new FavoritesData(context);
            var fakeFavorites1 = new Favorites { Id = 1, TouristId = 1, ActivitiesId = 1, IsActive = true };
            var fakeFavorites2 = new Favorites { Id = 2, TouristId = 2, ActivitiesId = 2, IsActive = true };

            await context.Favorites.AddRangeAsync(fakeFavorites1, fakeFavorites2);
            await context.SaveChangesAsync();

            // Act
            var result = await favoritesData.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }

    [Fact]
    public async Task GetAll_WhenNoFavoritesExist_ShouldReturnEmptyList()
    {
        // Arrange
        var options = GetDbOptions("GetAll_DB_NoFavorites");
        using (var context = new AppDbContext(options))
        {
            var favoritesData = new FavoritesData(context);

            // Act
            var result = await favoritesData.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }

    [Fact]
    public async Task Create_ShouldReturnTrue()
    {
        // Arrange
        var options = GetDbOptions("Create_DB");
        using (var context = new AppDbContext(options))
        {
            var favoritesData = new FavoritesData(context);
            var newFavorites = new Favorites { TouristId = 1, ActivitiesId = 1, IsActive = true };

            // Act
            var result = await favoritesData.Create(newFavorites);

            // Assert
            Assert.True(result);
            Assert.NotEqual(0, newFavorites.Id);
        }
    }

    [Fact]
    public async Task Update_WhenFavoritesExists_ShouldReturnTrue()
    {
        // Arrange
        var options = GetDbOptions("Update_DB");
        using (var context = new AppDbContext(options))
        {
            var favoritesData = new FavoritesData(context);
            var fakeFavorites = new Favorites { Id = 1, TouristId = 1, ActivitiesId = 1, IsActive = true };

            await context.Favorites.AddAsync(fakeFavorites);
            await context.SaveChangesAsync();

            var updatedFavorites = new Favorites { Id = fakeFavorites.Id, TouristId = 2, ActivitiesId = 2, IsActive = true };

            // Act
            var result = await favoritesData.Update(updatedFavorites);

            // Assert
            Assert.True(result);
        }
    }

    [Fact]
    public async Task Update_WhenFavoritesDoesNotExist_ShouldReturnFalse()
    {
        // Arrange
        var options = GetDbOptions("Update_DB_NotExist");
        using (var context = new AppDbContext(options))
        {
            var favoritesData = new FavoritesData(context);
            var updatedFavorites = new Favorites { Id = 1, TouristId = 1, ActivitiesId = 1, IsActive = true };

            // Act
            var result = await favoritesData.Update(updatedFavorites);

            // Assert
            Assert.False(result);
        }
    }

    [Fact]
    public async Task Delete_WhenFavoritesExists_ShouldReturnTrue()
    {
        // Arrange
        var options = GetDbOptions("Delete_DB");
        using (var context = new AppDbContext(options))
        {
            var favoritesData = new FavoritesData(context);
            var fakeFavorites = new Favorites { Id = 1, TouristId = 1, ActivitiesId = 1, IsActive = true };

            await context.Favorites.AddAsync(fakeFavorites);
            await context.SaveChangesAsync();

            // Act
            var result = await favoritesData.Delete(fakeFavorites.Id);

            // Assert
            Assert.True(result);
        }
    }

    [Fact]
    public async Task Delete_WhenFavoritesDoesNotExist_ShouldReturnFalse()
    {
        // Arrange
        var options = GetDbOptions("Delete_DB_NotExist");
        using (var context = new AppDbContext(options))
        {
            var favoritesData = new FavoritesData(context);

            // Act
            var result = await favoritesData.Delete(1);

            // Assert
            Assert.False(result);
        }
    }
}
