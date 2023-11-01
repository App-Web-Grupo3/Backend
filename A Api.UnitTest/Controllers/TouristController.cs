using AutoMapper;
using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using UniqueTrip.Controllers;
using UniqueTrip.Request;
using UniqueTrip.Response;

public class TouristControllerTest
{
    [Fact]
    public async Task GetAll_ShouldReturnListOfTouristResponse()
    {
        // Arrange
        var touristDomainMock = Substitute.For<ITouristDomain>();
        var touristDataMock = Substitute.For<ITouristData>();
        var mapperMock = Substitute.For<IMapper>();

        var touristController = new TouristController(touristDomainMock, touristDataMock, mapperMock);

        // Mock GetAll
        var fakeTouristList = new List<Tourist>
        {
            new Tourist { Id = 1, Name = "John", LastName = "Doe", Mail = "john@example.com", Password = "password", Phone = "123456789", Comments = new List<Comment>(), DateCreated = DateTime.Now },
            new Tourist { Id = 2, Name = "Jane", LastName = "Doe", Mail = "jane@example.com", Password = "password", Phone = "987654321", Comments = new List<Comment>(), DateCreated = DateTime.Now }
        };
        touristDataMock.GetAll().Returns(Task.FromResult(fakeTouristList));

        // Mock Mapper
        var fakeTouristResponseList = new List<TouristResponse>
        {
            new TouristResponse { Name = "John", LastName = "Doe", Mail = "john@example.com", Phone = "123456789", DateCreated = DateTime.Now },
            new TouristResponse { Name = "Jane", LastName = "Doe", Mail = "jane@example.com", Phone = "987654321", DateCreated = DateTime.Now }
        };
        mapperMock.Map<List<Tourist>, List<TouristResponse>>(fakeTouristList).Returns(fakeTouristResponseList);

        // Act
        var result = await touristController.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<TouristResponse>>(result);
        Assert.Equal(2, result.Count);
    }
    
            [Fact]
        public async Task GetById_ShouldReturnTouristResponse()
        {
            // Arrange
            var touristDomainMock = Substitute.For<ITouristDomain>();
            var touristDataMock = Substitute.For<ITouristData>();
            var mapperMock = Substitute.For<IMapper>();

            var touristController = new TouristController(touristDomainMock, touristDataMock, mapperMock);

            var fakeTourist = new Tourist { Id = 1, Name = "John", LastName = "Doe", Mail = "john@example.com", Password = "password", Phone = "123456789", Comments = new List<Comment>(), DateCreated = DateTime.Now };
            touristDataMock.GetById(Arg.Any<int>()).Returns(Task.FromResult(fakeTourist));

            var fakeTouristResponse = new TouristResponse { Name = "John", LastName = "Doe", Mail = "john@example.com", Phone = "123456789", DateCreated = DateTime.Now };
            mapperMock.Map<Tourist, TouristResponse>(fakeTourist).Returns(fakeTouristResponse);

            // Act
            var result = await touristController.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TouristResponse>(result);
        }

        [Fact]
        public async Task GetByName_ShouldReturnListOfTouristResponse()
        {
            // Arrange
            var touristDomainMock = Substitute.For<ITouristDomain>();
            var touristDataMock = Substitute.For<ITouristData>();
            var mapperMock = Substitute.For<IMapper>();

            var touristController = new TouristController(touristDomainMock, touristDataMock, mapperMock);

            // Mock GetByName
            var fakeTouristList = new List<Tourist>
            {
                new Tourist { Id = 1, Name = "John", LastName = "Doe", Mail = "john@example.com", Password = "password", Phone = "123456789", Comments = new List<Comment>(), DateCreated = DateTime.Now },
                new Tourist { Id = 2, Name = "John", LastName = "Doe", Mail = "jane@example.com", Password = "password", Phone = "987654321", Comments = new List<Comment>(), DateCreated = DateTime.Now }
            };
            touristDataMock.GetByName(Arg.Any<Tourist>()).Returns(Task.FromResult(fakeTouristList));

            // Act
            var result = await touristController.GetByName("John");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<TouristResponse>>(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetByPhone_ShouldReturnListOfTouristResponse()
        {
            // Arrange
            var touristDomainMock = Substitute.For<ITouristDomain>();
            var touristDataMock = Substitute.For<ITouristData>();
            var mapperMock = Substitute.For<IMapper>();

            var touristController = new TouristController(touristDomainMock, touristDataMock, mapperMock);

            // Mock GetByPhone
            var fakeTouristList = new List<Tourist>
            {
                new Tourist { Id = 1, Name = "John", LastName = "Doe", Mail = "john@example.com", Password = "password", Phone = "123456789", Comments = new List<Comment>(), DateCreated = DateTime.Now },
                new Tourist { Id = 2, Name = "Jane", LastName = "Doe", Mail = "jane@example.com", Password = "password", Phone = "123456789", Comments = new List<Comment>(), DateCreated = DateTime.Now }
            };
            touristDataMock.GetByPhone(Arg.Any<Tourist>()).Returns(Task.FromResult(fakeTouristList));

            // Act
            var result = await touristController.GetByPhone("123456789");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<TouristResponse>>(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Post_ShouldReturnOkResult()
        {
            // Arrange
            var touristDomainMock = Substitute.For<ITouristDomain>();
            var touristDataMock = Substitute.For<ITouristData>();
            var mapperMock = Substitute.For<IMapper>();

            var touristController = new TouristController(touristDomainMock, touristDataMock, mapperMock);

            var touristRequest = new TouristRequest { Name = "John", LastName = "Doe", Mail = "john@example.com", Password = "password", Phone = "123456789" };
            var fakeTourist = new Tourist { Id = 1, Name = "John", LastName = "Doe", Mail = "john@example.com", Password = "password", Phone = "123456789", Comments = new List<Comment>(), DateCreated = DateTime.Now };

            touristDomainMock.Create(Arg.Is<Tourist>(t =>
                t.Name == fakeTourist.Name &&
                t.LastName == fakeTourist.LastName &&
                t.Mail == fakeTourist.Mail &&
                t.Password == fakeTourist.Password &&
                t.Phone == fakeTourist.Phone)).Returns(Task.FromResult(true));

            // Act
            var result = await touristController.Post(touristRequest);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_ShouldReturnOkResult()
        {
            // Arrange
            var touristDomainMock = Substitute.For<ITouristDomain>();
            var touristDataMock = Substitute.For<ITouristData>();
            var mapperMock = Substitute.For<IMapper>();

            var touristController = new TouristController(touristDomainMock, touristDataMock, mapperMock);

            var touristRequest = new TouristRequest { Name = "John", LastName = "Doe", Mail = "john@example.com", Password = "password", Phone = "123456789" };
            var fakeTourist = new Tourist { Id = 1, Name = "John", LastName = "Doe", Mail = "john@example.com", Password = "password", Phone = "123456789", Comments = new List<Comment>(), DateCreated = DateTime.Now };

            touristDomainMock.Create(Arg.Is<Tourist>(t =>
                t.Name == fakeTourist.Name &&
                t.LastName == fakeTourist.LastName &&
                t.Mail == fakeTourist.Mail &&
                t.Password == fakeTourist.Password &&
                t.Phone == fakeTourist.Phone)).Returns(Task.FromResult(true));

            // Act
            var result = await touristController.Put(1, touristRequest);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnTrue()
        {
            // Arrange
            var touristDomainMock = Substitute.For<ITouristDomain>();
            var touristDataMock = Substitute.For<ITouristData>();
            var mapperMock = Substitute.For<IMapper>();

            var touristController = new TouristController(touristDomainMock, touristDataMock, mapperMock);

            touristDomainMock.Delete(Arg.Any<int>()).Returns(Task.FromResult(true));

            // Act
            var result = await touristController.Delete(1);

            // Assert
            Assert.True(result);
        }
}

