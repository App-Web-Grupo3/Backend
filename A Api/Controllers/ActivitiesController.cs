using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniqueTrip.Request;
using UniqueTrip.Response;

namespace UniqueTrip.Controllers
{
    [ApiController]
    [Route("api/v1/Activities")]
    public class ActivitiesController : Controller
    {
        private readonly IActivitiesDomain _activitiesDomain;
        private readonly IActivitiesData _activitiesData;
        private readonly IMapper _mapper;
        
        public ActivitiesController(IActivitiesDomain activitiesDomain, IActivitiesData activitiesData, IMapper mapper)
        {
            _activitiesDomain = activitiesDomain;
            _activitiesData = activitiesData;
            _mapper = mapper;
        }
        // GET: api/Activities
        [HttpGet]
        public async Task<List<ActivitiesResponse>> GetAll()
        {
            var response = await _activitiesData.GetAll();
            var result = _mapper.Map<List<Activities>, List<ActivitiesResponse>>(response);
            return result;
        }

        // GET: api/Activities/5
        [HttpGet("{id}", Name = "GetActivityById")]
        public async Task<ActivitiesResponse> GetById(int id)
        {
            var response = await _activitiesData.GetById(id);
            var result = _mapper.Map<Activities, ActivitiesResponse>(response);
            return result;
        }

        // GET: api/Activities/title
        [HttpGet("{title}")]
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
        public async Task<IActionResult> Post([FromBody] ActivitiesRequest activitiesRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = _mapper.Map<ActivitiesRequest, Activities>(activitiesRequest);
                return Ok(await _activitiesDomain.Create(result));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Activities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ActivitiesRequest activitiesRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = _mapper.Map<ActivitiesRequest, Activities>(activitiesRequest);
                return Ok(await _activitiesDomain.Update(result, id));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _activitiesDomain.Delete(id);
        }
    }
}