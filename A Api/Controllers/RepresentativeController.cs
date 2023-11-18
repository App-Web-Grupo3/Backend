using AutoMapper;
using Data.Model;
using Domain.Service.Impl;
using Microsoft.AspNetCore.Mvc;
using UniqueTrip.Request;
using UniqueTrip.Response;

namespace UniqueTrip.Controllers;

[ApiController]
[Route("/api/v1/representative")]
public class RepresentativeController: ControllerBase
{
    private readonly IRepresentativeDomain _representativeDomain;
    private readonly IMapper _mapper;
    
    public RepresentativeController(IRepresentativeDomain representativeDomain, IMapper mapper)
    {
        _representativeDomain = representativeDomain;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<RepresentativeResponse>> GetAllAsync()
    {
        var representante = await _representativeDomain.ListAsync();
        var response = _mapper.Map<IEnumerable<Representative>, IEnumerable<RepresentativeResponse>>(representante);
        return response;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var representante = await _representativeDomain.GetByIdAsync(id);
        var response = _mapper.Map<Representative, RepresentativeResponse>(representante);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RepresentativeRequest resource)
    {
        try
        {
            if (resource.Phone.Length > 9)
            {
                return BadRequest(new { Message = "The phone number cannot be longer than 9 characters" });
            }

            var representante = _mapper.Map<RepresentativeRequest, Representative>(resource);
            await _representativeDomain.SaveAsync(representante);
            
            return Ok(resource);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] RepresentativeRequest resource)
    {
     
        var activity = _mapper.Map<RepresentativeRequest, Representative>(resource);

        var result = await _representativeDomain.UpdateAsync(id, activity);

        var activityResource = _mapper.Map<Representative, RepresentativeResponse>(result);

        return Ok(activityResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _representativeDomain.DeleteAsync(id);
        
        var activityResource = _mapper.Map<Representative, RepresentativeResponse>(result);

        return Ok(activityResource);
    }




}