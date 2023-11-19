using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Model;
using Domain.Service;
using Domain.Service.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniqueTrip.Request;
using UniqueTrip.Response;

namespace UniqueTrip.Controllers
{
    [Route("api/v1/PurchaseDetail")]
    [ApiController]
    public class PurchaseDetailController : ControllerBase
    {
       private readonly IPurchaseDetailDomain _purchaseDetailDomain;
        private readonly IMapper _mapper;
        
        public PurchaseDetailController(IPurchaseDetailDomain purchaseDetailDomain, IMapper mapper)
        {
            _purchaseDetailDomain = purchaseDetailDomain;
            _mapper = mapper;
        }
        // GET: api/Response
        [HttpGet("GetAllPurchaseDetail")]
        public async Task<List<PurchaseDetailResponse>> GetAll()
        {
            var response = await _purchaseDetailDomain.GetAll();
            var result = _mapper.Map<List<PurchaseDetail>, List<PurchaseDetailResponse>>(response);
            return result;
        }

        // GET: api/Company/5
        [HttpGet("{id}", Name = "GetPurchaseDetailById")]
        public async Task<PurchaseDetailResponse> GetById(int id)
        {
            var purchaseDetail = await _purchaseDetailDomain.GetById(id);
            var response = _mapper.Map<PurchaseDetail, PurchaseDetailResponse>(purchaseDetail);
            return response;
        }
        // GET: api/Company/name
        [HttpGet("GetPurchaseDetailByState")]
        public async Task<List<PurchaseDetailResponse>> GetByState(string state)
        {
            PurchaseDetail purchaseDetail = new PurchaseDetail()
            {
                State = state,
            };
            var purchaseDetailByState = await _purchaseDetailDomain.GetByState(purchaseDetail);
            var response = _mapper.Map<List<PurchaseDetail>, List<PurchaseDetailResponse>>(purchaseDetailByState);
            return response;
        }
        
        // POST: api/Company
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PurchaseDetailRequest purchaseDetailRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var tourist = _mapper.Map<PurchaseDetailRequest, PurchaseDetail>(purchaseDetailRequest);
                return Ok(await _purchaseDetailDomain.Create(tourist));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PurchaseDetailRequest purchaseDetailRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var tourist = _mapper.Map<PurchaseDetailRequest, PurchaseDetail>(purchaseDetailRequest);
                return Ok(await _purchaseDetailDomain.Update(tourist, id));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _purchaseDetailDomain.Delete(id);
        }
    }
}
