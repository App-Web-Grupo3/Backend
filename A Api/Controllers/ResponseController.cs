using AutoMapper;
using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;
using Microsoft.AspNetCore.Mvc;
using UniqueTrip.Request;
using UniqueTrip.Response;

namespace UniqueTrip.Controllers
{
    [Route("api/v1/Response")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly IResponseDomain _responseDomain;
        private readonly IResponseData _responseData;
        private readonly IMapper _mapper;
        
        public ResponseController(IResponseDomain responseDomain, IResponseData responseData, IMapper mapper)
        {
            _responseDomain = responseDomain;
            _responseData = responseData;
            _mapper = mapper;
        }
        
        // GET: api/Response
        [HttpGet("GetAllResponse")]
        public async Task<List<ResResponse>> GetAll()
        {
            var response = await _responseData.GetAll();
            var result = _mapper.Map<List<Answer>, List<ResResponse>>(response);
            return result;
        }

        // GET: api/Response/5
        [HttpGet("{id}", Name = "GetResponseById")]
        public async Task<ResResponse> GetById(int id)
        {
            var response = await _responseData.GetById(id);
            var result = _mapper.Map<Answer, ResResponse>(response);
            return result;
        }

        // GET: api/Response/response
        [HttpGet("GetByResponse")]
        public async Task<List<ResResponse>> GetByResponse(string answer)
        {
            Answer initial = new Answer()
            {
                response = answer,
            };
            var response = await _responseData.GetByResponse(initial);
            var result = _mapper.Map<List<Answer>, List<ResResponse>>(response);
            return result;
        }
        // POST: api/Response
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ResponseRequest responseRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = _mapper.Map<ResponseRequest, Answer>(responseRequest);
                return Ok(await _responseDomain.Create(result));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Response/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ResponseRequest responseRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = _mapper.Map<ResponseRequest, Answer>(responseRequest);
                return Ok(await _responseDomain.Update(result, id));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Response/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _responseDomain.Delete(id);
        }
    }
}
