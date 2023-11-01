using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service;
using NSubstitute;

namespace B_Domain.UnitTest.ServiceTest;

public class TouristDomainTest
{
            [Fact]
        public async Task GetById_WhenTouristExists_ReturnsTourist()
        {
            // Arrange
            var touristDataMock = Substitute.For<ITouristData>();
            var touristDomain = new TouristDomain(touristDataMock);

            var fakeTourist = new Tourist { Id = 1, Name = "John Doe", Phone = "123456789" };
            touristDataMock.GetById(Arg.Any<int>()).Returns(Task.FromResult(fakeTourist));

            // Act
            var result = await touristDomain.GetById(fakeTourist.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(fakeTourist.Id, result.Id);
            Assert.Equal(fakeTourist.Name, result.Name);
            Assert.Equal(fakeTourist.Phone, result.Phone);
        }

        [Fact]
        public async Task GetByName_ShouldReturnListOfTourists()
        {
            // Arrange
            var touristDataMock = Substitute.For<ITouristData>();
            var touristDomain = new TouristDomain(touristDataMock);

            var fakeTouristList = new List<Tourist>
            {
                new Tourist { Id = 1, Name = "John Doe", Phone = "123456789" },
                new Tourist { Id = 2, Name = "Jane Doe", Phone = "987654321" }
            };
            touristDataMock.GetByName(Arg.Any<Tourist>()).Returns(Task.FromResult(fakeTouristList));

            // Act
            var result = await touristDomain.GetByName(new Tourist());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(fakeTouristList.Count, result.Count);
        }

        [Fact]
        public async Task GetAll_ShouldReturnListOfTourists()
        {
            // Arrange
            var touristDataMock = Substitute.For<ITouristData>();
            var touristDomain = new TouristDomain(touristDataMock);

            var fakeTouristList = new List<Tourist>
            {
                new Tourist { Id = 1, Name = "John Doe", Phone = "123456789" },
                new Tourist { Id = 2, Name = "Jane Doe", Phone = "987654321" }
            };
            touristDataMock.GetAll().Returns(Task.FromResult(fakeTouristList));

            // Act
            var result = await touristDomain.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(fakeTouristList.Count, result.Count);
        }

        [Fact]
        public async Task GetByPhone_ShouldReturnListOfTourists()
        {
            // Arrange
            var touristDataMock = Substitute.For<ITouristData>();
            var touristDomain = new TouristDomain(touristDataMock);

            var fakeTouristList = new List<Tourist>
            {
                new Tourist { Id = 1, Name = "John Doe", Phone = "123456789" },
                new Tourist { Id = 2, Name = "Jane Doe", Phone = "987654321" }
            };
            touristDataMock.GetByPhone(Arg.Any<Tourist>()).Returns(Task.FromResult(fakeTouristList));

            // Act
            var result = await touristDomain.GetByPhone(new Tourist());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(fakeTouristList.Count, result.Count);
        }

        [Fact]
        public async Task Create_ShouldReturnTrue()
        {
            // Arrange
            var touristDataMock = Substitute.For<ITouristData>();
            var touristDomain = new TouristDomain(touristDataMock);

            var fakeTourist = new Tourist { Name = "John Doe", Phone = "123456789" };
            touristDataMock.GetByPhone(Arg.Any<Tourist>()).Returns(Task.FromResult(new List<Tourist>()));
            touristDataMock.Create(Arg.Any<Tourist>()).Returns(Task.FromResult(true));

            // Act
            var result = await touristDomain.Create(fakeTourist);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Update_ShouldReturnTrue()
        {
            // Arrange
            var touristDataMock = Substitute.For<ITouristData>();
            var touristDomain = new TouristDomain(touristDataMock);

            var fakeTourist = new Tourist { Id = 1, Name = "John Doe", Phone = "123456789" };
            touristDataMock.GetByPhone(Arg.Any<Tourist>()).Returns(Task.FromResult(new List<Tourist>()));
            touristDataMock.Update(Arg.Any<Tourist>(), Arg.Any<int>()).Returns(Task.FromResult(true));

            // Act
            var result = await touristDomain.Update(fakeTourist, fakeTourist.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnTrue()
        {
            // Arrange
            var touristDataMock = Substitute.For<ITouristData>();
            var touristDomain = new TouristDomain(touristDataMock);

            var fakeTourist = new Tourist { Id = 1, Name = "John Doe", Phone = "123456789" };
            touristDataMock.GetById(Arg.Any<int>()).Returns(Task.FromResult(fakeTourist));
            touristDataMock.Delete(Arg.Any<int>()).Returns(Task.FromResult(true));

            // Act
            var result = await touristDomain.Delete(fakeTourist.Id);

            // Assert
            Assert.True(result);
        }
}