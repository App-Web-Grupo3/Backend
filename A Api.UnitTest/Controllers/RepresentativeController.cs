using AutoMapper;
using Data.Model;
using Domain.Service.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using UniqueTrip.Controllers;
using UniqueTrip.Request;
using UniqueTrip.Response;
using Xunit;


public class RepresentativeControllerTest
{
    
    [Fact]
    public async void GetByIdTest()
    {
        var respresentativeDomainMock = Substitute.For<IRepresentativeDomain>();
        var mapperMock = Substitute.For<IMapper>();
        var controller = new RepresentativeController(respresentativeDomainMock, mapperMock);

        var representative1 = new RepresentativeRequest
        {
            Name = "Juan Manuel",
            LastName = "Vargas",
            Mail = "juan@gmail.com",
            Password = "123456",
            Phone = "123456789"
        };
        await controller.PostAsync(representative1);

        var representative2 = new RepresentativeRequest
        {
            Name = "Maria",
            LastName = "Bermudez",
            Mail = "maria@gmail.com",
            Password = "123456",
            Phone = "987654323",
        };
        await controller.PostAsync(representative2);

        // Convierte el objeto `representative2` a un objeto `RepresentanteResponse`.
        var representative2Response = mapperMock.Map<RepresentativeRequest, RepresentativeResponse>(representative2);
          
        var result =  controller.GetById(2);
        
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async void PostAsyncTest_ReturnsOk()
    {

        var respresentativeDomainMock = Substitute.For<IRepresentativeDomain>();
        var mapperMock = Substitute.For<IMapper>();

        var controller = new RepresentativeController(respresentativeDomainMock, mapperMock);

        var representativeD = new RepresentativeRequest
        {
            Name = "Juan Manuel",
            LastName = "Vargas",
            Mail = "juan@gmail.com",
            Password = "123456",
            Phone = "123456789",
        };

        var representative = new Representative();
        mapperMock.Map<RepresentativeRequest, Representative>(representativeD).Returns(representative);

        var result = await controller.PostAsync(representativeD);
       
       

        Assert.IsType<OkObjectResult>(result);
    }
    
    [Fact]
    public async void PostAsyncTest_ReturnsBadRequest()
    {

        var respresentativeDomainMock = Substitute.For<IRepresentativeDomain>();
        var mapperMock = Substitute.For<IMapper>();
        var controller = new RepresentativeController(respresentativeDomainMock, mapperMock);
       
        
        // Solicitud inválida con número de teléfono largo
        var representativeInvalid = new RepresentativeRequest
        {
            Name = "Maria",
            LastName = "Sandoval",
            Mail = "maria@gmail.com",
            Password = "123456",
            Phone = "123456789566778978678",
        };

         var result = await controller.PostAsync(representativeInvalid);


        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
    
}