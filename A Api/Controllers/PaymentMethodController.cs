using AutoMapper;
using Data.Model;
using Domain.Service.Impl;
using Microsoft.AspNetCore.Mvc;
using UniqueTrip.Request;
using UniqueTrip.Response;

namespace UniqueTrip.Controllers;

[ApiController]
[Route("/api/v1/PaymentMethod")]
public class PaymentMethodController : ControllerBase
{
    private readonly IPaymentMethodDomain _paymentMethodDomain;
    private readonly IMapper _mapper;
    
     public PaymentMethodController(IPaymentMethodDomain paymentMethodDomain, IMapper mapper)
    {
        _paymentMethodDomain = paymentMethodDomain;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PaymentMethodResponse>> GetAllAsync()
    {
        var paymentMethod = await _paymentMethodDomain.ListAsync();
        var response = _mapper.Map<IEnumerable<PaymentMethod>, IEnumerable<PaymentMethodResponse>>(paymentMethod);
        return response;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var paymentMethod = await _paymentMethodDomain.GetByIdAsync(id);
        var response = _mapper.Map<PaymentMethod, PaymentMethodResponse>(paymentMethod);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] PaymentMethodRequest resource)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var paymentMethod = _mapper.Map<PaymentMethodRequest, PaymentMethod>(resource);
            await _paymentMethodDomain.SaveAsync(paymentMethod);
            
            return Ok(resource);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] PaymentMethodRequest resource)
    {
     
        var activity = _mapper.Map<PaymentMethodRequest, PaymentMethod>(resource);

        var result = await _paymentMethodDomain.UpdateAsync(id, activity);

        var activityResource = _mapper.Map<PaymentMethod, PaymentMethodResponse>(result);

        return Ok(activityResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _paymentMethodDomain.DeleteAsync(id);
        
        var activityResource = _mapper.Map<PaymentMethod, PaymentMethodResponse>(result);

        return Ok(activityResource);
    }
}