using AutoMapper;
using Data.Model;
using Domain.Service.Impl;
using Microsoft.AspNetCore.Mvc;
using UniqueTrip.Request;
using UniqueTrip.Response;

namespace UniqueTrip.Controllers;

[ApiController]
[Route("/api/v1/representante")]
public class RepresentanteController: ControllerBase
{
    private readonly IRepresentanteDomain _representanteDomain;
    private readonly IMapper _mapper;
    
    public RepresentanteController(IRepresentanteDomain representanteDomain, IMapper mapper)
    {
        _representanteDomain = representanteDomain;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<RepresentanteResponse>> GetAllAsync()
    {
        var respresentate = await _representanteDomain.ListAsync();
        var response = _mapper.Map<IEnumerable<Representante>, IEnumerable<RepresentanteResponse>>(respresentate);
        return response;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var representante = await _representanteDomain.GetByIdAsync(id);
        var response = _mapper.Map<Representante, RepresentanteResponse>(representante);
        return Ok(response);
    }




}