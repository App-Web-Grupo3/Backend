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


public class RepresentanteControllerTest
{


    [Fact]
    public async void GetByIdTest()
    {
        var respresentativeDomainMock = Substitute.For<IRepresentanteDomain>();
        var mapperMock = Substitute.For<IMapper>();
        var controller = new RepresentanteController(respresentativeDomainMock, mapperMock);

        var representative1 = new RepresentanteRequest
        {
            Nombre = "Juan Manuel",
            Apellido = "Vargas",
            Correo = "juan@gmail.com",
            Contrasenia = "123456",
            Telefono = "123456789"
        };
        await controller.PostAsync(representative1);

        var representative2 = new RepresentanteRequest
        {
            Nombre = "Maria",
            Apellido = "Bermudez",
            Correo = "maria@gmail.com",
            Contrasenia = "123456",
            Telefono = "987654323",
        };
        await controller.PostAsync(representative2);

        // Convierte el objeto `representative2` a un objeto `RepresentanteResponse`.
        var representative2Response = mapperMock.Map<RepresentanteRequest, RepresentanteResponse>(representative2);
          
        var result =  controller.GetById(2);
        
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async void PostAsyncTest_ReturnsOk()
    {

        var respresentativeDomainMock = Substitute.For<IRepresentanteDomain>();
        var mapperMock = Substitute.For<IMapper>();

        var controller = new RepresentanteController(respresentativeDomainMock, mapperMock);

        var representativeD = new RepresentanteRequest
        {
            Nombre = "Juan Manuel",
            Apellido = "Vargas",
            Correo = "juan@gmail.com",
            Contrasenia = "123456",
            Telefono = "123456789",
        };

        var representative = new Representante();
        mapperMock.Map<RepresentanteRequest, Representante>(representativeD).Returns(representative);

        var result = await controller.PostAsync(representativeD);
       
       

        Assert.IsType<OkObjectResult>(result);
    }
    
    [Fact]
    public async void PostAsyncTest_ReturnsBadRequest()
    {

        var respresentativeDomainMock = Substitute.For<IRepresentanteDomain>();
        var mapperMock = Substitute.For<IMapper>();
        var controller = new RepresentanteController(respresentativeDomainMock, mapperMock);
       
        
        // Solicitud inválida con número de teléfono largo
        var representativeInvalid = new RepresentanteRequest
        {
            Nombre = "Maria",
            Apellido = "Sandoval",
            Correo = "maria@gmail.com",
            Contrasenia = "123456",
            Telefono = "123456789566778978678",
        };

         var result = await controller.PostAsync(representativeInvalid);


        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
    
}