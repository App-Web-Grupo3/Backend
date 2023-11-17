using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Model;
using Domain.Service.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniqueTrip.Request;
using UniqueTrip.Response;

namespace UniqueTrip.Controllers
{
    [Route("api/v1/Payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        
        private readonly IPaymentDomain _paymentDomain;
        private readonly IMapper _mapper;
        
        public PaymentController(IPaymentDomain paymentDomain, IMapper mapper)
        {
            _paymentDomain = paymentDomain;
            _mapper = mapper;
        }
        // GET: api/Response
        [HttpGet("GetAllPayments")]
        public async Task<List<PaymentResponse>> GetAll()
        {
            var payment = await _paymentDomain.GetAll();
            var result = _mapper.Map<List<Payment>, List<PaymentResponse>>(payment);
            return result;
        }

        // GET: api/Payment/5
        [HttpGet("{id}", Name = "GetPaymentById")]
        public async Task<PaymentResponse> GetById(int id)
        {
            var payment = await _paymentDomain.GetById(id);
            var response = _mapper.Map<Payment, PaymentResponse>(payment);
            return response;
        }
        
        
        // GET: api/Payment/name
        [HttpGet("GetPaymentByName")]
        public async Task<List<PaymentResponse>> GetByAmount(int amount)
        {
            Payment payment = new Payment()
            {
                Amount = amount,
            };
            var paymentByAmount = await _paymentDomain.GetByAmount(payment);
            var response = _mapper.Map<List<Payment>, List<PaymentResponse>>(paymentByAmount);
            return response;
        }
        
        
        // POST: api/Payment
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentRequest paymentRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var payment = _mapper.Map<PaymentRequest, Payment>(paymentRequest);
                return Ok(await _paymentDomain.Create(payment));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PaymentRequest paymentRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var payment = _mapper.Map<PaymentRequest, Payment>(paymentRequest);
                return Ok(await _paymentDomain.Update(payment, id));
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
            return await _paymentDomain.Delete(id);
        }
    }
}
