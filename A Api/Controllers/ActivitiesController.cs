using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniqueTrip.Request;
using UniqueTrip.Response;

namespace UniqueTrip.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ActivitiesController : Controller
    {
        private readonly IActivitiesDomain _activitiesDomain;
        private readonly IActivitiesData _activitiesData;
        private readonly IMapper _mapper;
        private TelemetryClient _telemetry;
        
        public ActivitiesController(IActivitiesDomain activitiesDomain, IActivitiesData activitiesData, 
            IMapper mapper, TelemetryClient telemetry)
        {
            _activitiesDomain = activitiesDomain;
            _activitiesData = activitiesData;
            _mapper = mapper;
            _telemetry = telemetry;
        }
        // GET: api/Activities
        [HttpGet("all")]
        public async Task<List<ActivitiesResponse>> GetAll()
        {
            var response = await _activitiesData.GetAll();
            var result = _mapper.Map<List<Activities>, List<ActivitiesResponse>>(response);
            return result;
        }

        // GET: api/Activities/5
        [HttpGet("id/{id}")]
        public async Task<ActivitiesResponse> GetById(int id)
        {
            var response = await _activitiesData.GetById(id);
            var result = _mapper.Map<Activities, ActivitiesResponse>(response);
            return result;
        }

        // GET: api/Activities/title
        [HttpGet("title/{title}")]
        public async Task<List<ActivitiesResponse>> GetByTitle(string title)
        {
            Activities initial = new Activities()
            {
                Title = title,
            };
            var response = await _activitiesData.GetByTitle(initial);
            var result = _mapper.Map<List<Activities>, List<ActivitiesResponse>>(response);
            return result;
        }
        // POST: api/Activities
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ActivitiesRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activity = _mapper.Map<ActivitiesRequest, Activities>(request);

            var result = await _activitiesDomain.AddActivity(activity);

            if (result.IsSuccess)
            {
                return Created($"/api/v1/activities/{result.Data.Id}", result.Data);
            }
            return BadRequest(result.ErrorMessage);
        }

        // PUT: api/Activities/5
        [HttpPut("id/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ActivitiesRequest activitiesRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _telemetry.TrackTrace("Put Bad Request");
                    return BadRequest();
                }

                var result = _mapper.Map<ActivitiesRequest, Activities>(activitiesRequest);
                _telemetry.TrackEvent("Put");
                return Ok(await _activitiesDomain.Update(result, id));
            }
            catch (Exception e)
            {
                _telemetry.TrackException(e);
                return StatusCode(500);
            }
        }

        // DELETE: api/Activities/5
        [HttpDelete("id/{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _activitiesDomain.Delete(id);
        }
    }
}