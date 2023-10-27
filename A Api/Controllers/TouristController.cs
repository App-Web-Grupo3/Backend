using AutoMapper;
using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;

using Microsoft.AspNetCore.Mvc;
using UniqueTrip.Request;
using Microsoft.AspNetCore.Http;
using UniqueTrip.Response;

namespace UniqueTrip.Controllers
{
    [Route("api/v1/Tourist")]
    [ApiController]
    public class TouristController : ControllerBase
    {
        private readonly ITouristDomain _touristDomain;
        private readonly ITouristData _touristData;
        private readonly IMapper _mapper;
        
        public TouristController(ITouristDomain touristDomain, ITouristData touristData, IMapper mapper)
        {
            _touristDomain = touristDomain;
            _touristData = touristData;
            _mapper = mapper;
        }
        // GET: api/Tourist
        [HttpGet("GetAll")]
        public async Task<List<TouristResponse>> GetAll()
        {
            var tourist = await _touristData.GetAll();
            var response = _mapper.Map<List<Tourist>, List<TouristResponse>>(tourist);
            return response;
        }

        // GET: api/Tourist/5
        [HttpGet("{id}", Name = "GetById")]
        public async Task<TouristResponse> GetById(int id)
        {
            var tourist = await _touristData.GetById(id);
            var response = _mapper.Map<Tourist, TouristResponse>(tourist);
            return response;
        }
        
        
        // POST: api/Tourist
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TouristRequest touristRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var tourist = _mapper.Map<TouristRequest, Tourist>(touristRequest);
                return Ok(await _touristDomain.Create(tourist));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Tourist/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TouristRequest touristRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var tourist = _mapper.Map<TouristRequest, Tourist>(touristRequest);
                return Ok(await _touristDomain.Update(tourist, id));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Tourist/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _touristDomain.Delete(id);
        }
    }
}
