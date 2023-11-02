using AutoMapper;
using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using UniqueTrip.Controllers;
using UniqueTrip.Request;
using UniqueTrip.Response;
using Xunit;

namespace UniqueTrip.UnitTest.Controllers
{
    public class FavoritesControllerTest
    {
        [Fact]
        public async Task GetAll_ShouldReturnListOfFavorites()
        {
            // Arrange
            var favoritesDomainMock = Substitute.For<IFavoritesDomain>();
            var favoritesDataMock = Substitute.For<IFavoritesData>();
            var mapperMock = Substitute.For<IMapper>();

            var controller = new FavoritesController(favoritesDomainMock, favoritesDataMock, mapperMock);

            var fakeFavoritesList = new List<Favorites>
            {
                new Favorites { Id = 1, TouristId = 1, ActivitiesId = 1, DateCreated = DateTime.Now },
                new Favorites { Id = 2, TouristId = 2, ActivitiesId = 2, DateCreated = DateTime.Now }
            };

            favoritesDataMock.GetAll().Returns(fakeFavoritesList);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<FavoritesResponse>>(result);
        }

        [Fact]
        public async Task GetById_WhenFavoritesExists_ShouldReturnFavoritesResponse()
        {
            // Arrange
            var favoritesDomainMock = Substitute.For<IFavoritesDomain>();
            var favoritesDataMock = Substitute.For<IFavoritesData>();
            var mapperMock = Substitute.For<IMapper>();

            var controller = new FavoritesController(favoritesDomainMock, favoritesDataMock, mapperMock);
            var fakeFavorites = new Favorites { Id = 1, TouristId = 1, ActivitiesId = 1, DateCreated = DateTime.Now };

            favoritesDataMock.GetById(1).Returns(fakeFavorites);

            // Act
            var result = await controller.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<FavoritesResponse>(result);
        }

        [Fact]
        public async Task Post_WithValidFavoritesRequest_ShouldReturnOkResult()
        {
            // Arrange
            var favoritesDomainMock = Substitute.For<IFavoritesDomain>();
            var favoritesDataMock = Substitute.For<IFavoritesData>();
            var mapperMock = Substitute.For<IMapper>();

            var controller = new FavoritesController(favoritesDomainMock, favoritesDataMock, mapperMock);
            var validFavoritesRequest = new FavoritesRequest { Tourist_id = 1, Activities_id = 1 };

            favoritesDomainMock.Create(Arg.Any<Favorites>()).Returns(true);

            // Act
            var result = await controller.Post(validFavoritesRequest);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_WithValidFavoritesRequest_ShouldReturnOkResult()
        {
            // Arrange
            var favoritesDomainMock = Substitute.For<IFavoritesDomain>();
            var favoritesDataMock = Substitute.For<IFavoritesData>();
            var mapperMock = Substitute.For<IMapper>();

            var controller = new FavoritesController(favoritesDomainMock, favoritesDataMock, mapperMock);
            var validFavoritesRequest = new FavoritesRequest { Tourist_id = 1, Activities_id = 1 };

            favoritesDomainMock.Update(Arg.Any<Favorites>(), 1).Returns(true);

            // Act
            var result = await controller.Put(1, validFavoritesRequest);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_WhenFavoritesExists_ShouldReturnTrue()
        {
            // Arrange
            var favoritesDomainMock = Substitute.For<IFavoritesDomain>();
            var favoritesDataMock = Substitute.For<IFavoritesData>();
            var mapperMock = Substitute.For<IMapper>();

            var controller = new FavoritesController(favoritesDomainMock, favoritesDataMock, mapperMock);
            favoritesDomainMock.Delete(1).Returns(true);

            // Act
            var result = await controller.Delete(1);

            // Assert
            Assert.True(result);
        }
    }
}
