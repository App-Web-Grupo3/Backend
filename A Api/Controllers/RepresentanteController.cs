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
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RepresentanteRequest resource)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var representante = _mapper.Map<RepresentanteRequest, Representante>(resource);
            await _representanteDomain.SaveAsync(representante);
            
            return Ok(resource);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] RepresentanteRequest resource)
    {
     
        var activity = _mapper.Map<RepresentanteRequest, Representante>(resource);

        var result = await _representanteDomain.UpdateAsync(id, activity);

        var activityResource = _mapper.Map<Representante, RepresentanteResponse>(result);

        return Ok(activityResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _representanteDomain.DeleteAsync(id);
        
        var activityResource = _mapper.Map<Representante, RepresentanteResponse>(result);

        return Ok(activityResource);
    }



}