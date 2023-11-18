using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service;
using NSubstitute;

namespace B_Domain.UnitTest.ServiceTest;

public class FavoritesDomainTest
{
    [Fact]
    public async Task GetById_WhenFavoritesExists_ShouldReturnFavorites()
    {
        // Arrange
        var favoritesDataMock = Substitute.For<IFavoritesData>();
        var domain = new FavoritesDomain(favoritesDataMock);
        var fakeFavorites = new Favorites { Id = 1};

        favoritesDataMock.GetById(1).Returns(fakeFavorites);

        // Act
        var result = await domain.GetById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fakeFavorites.Id, result.Id);
    }

    [Fact]
    public async Task GetById_WhenFavoritesDoesNotExist_ShouldThrowKeyNotFoundException()
    {
        // Arrange
        var favoritesDataMock = Substitute.For<IFavoritesData>();
        var domain = new FavoritesDomain(favoritesDataMock);
        favoritesDataMock.GetById(1).Returns((Favorites)null);

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(async () => await domain.GetById(1));
    }

    [Fact]
    public async Task GetAll_ShouldReturnListOfFavorites()
    {
        // Arrange
        var favoritesDataMock = Substitute.For<IFavoritesData>();
        var domain = new FavoritesDomain(favoritesDataMock);
        var fakeFavoritesList = new List<Favorites>
        {
            new Favorites { Id = 1},
            new Favorites { Id = 2}
        };

        favoritesDataMock.GetAll().Returns(fakeFavoritesList);

        // Act
        var result = await domain.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fakeFavoritesList.Count, result.Count);
    }

    [Fact]
    public async Task Create_WithValidFavorites_ShouldReturnTrue()
    {
        // Arrange
        var favoritesDataMock = Substitute.For<IFavoritesData>();
        var domain = new FavoritesDomain(favoritesDataMock);
        var validFavorites = new Favorites { Id = 1 };

        favoritesDataMock.Create(validFavorites).Returns(true);

        // Act
        var result = await domain.Create(validFavorites);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Update_WithValidFavorites_ShouldReturnTrue()
    {
        // Arrange
        var favoritesDataMock = Substitute.For<IFavoritesData>();
        var domain = new FavoritesDomain(favoritesDataMock);
        var validFavorites = new Favorites { Id = 1 };

        favoritesDataMock.GetById(1).Returns(validFavorites);
        favoritesDataMock.Update(validFavorites).Returns(true);

        // Act
        var result = await domain.Update(validFavorites, 1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Update_WithNonExistingFavorites_ShouldReturnFalse()
    {
        // Arrange
        var favoritesDataMock = Substitute.For<IFavoritesData>();
        var domain = new FavoritesDomain(favoritesDataMock);
        var invalidFavorites = new Favorites { Id = 1 };

        favoritesDataMock.GetById(1).Returns((Favorites)null);

        // Act
        var result = await domain.Update(invalidFavorites, 1);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task Delete_WhenFavoritesExists_ShouldReturnTrue()
    {
        // Arrange
        var favoritesDataMock = Substitute.For<IFavoritesData>();
        var domain = new FavoritesDomain(favoritesDataMock);
        var fakeFavorites = new Favorites { Id = 1 };

        favoritesDataMock.GetById(1).Returns(fakeFavorites);
        favoritesDataMock.Delete(1).Returns(true);

        // Act
        var result = await domain.Delete(1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Delete_WhenFavoritesDoesNotExist_ShouldReturnFalse()
    {
        // Arrange
        var favoritesDataMock = Substitute.For<IFavoritesData>();
        var domain = new FavoritesDomain(favoritesDataMock);

        favoritesDataMock.GetById(1).Returns((Favorites)null);

        // Act
        var result = await domain.Delete(1);

        // Assert
        Assert.False(result);
    }
}
