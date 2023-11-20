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
    [Route("api/v1/Company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyDomain _companyDomain;
        private readonly IMapper _mapper;
        
        public CompanyController(ICompanyDomain companyDomain, IMapper mapper)
        {
            _companyDomain = companyDomain;
            _mapper = mapper;
        }
        // GET: api/Response
        [HttpGet("GetAllCompanies")]
        public async Task<List<CompanyResponse>> GetAll()
        {
            var response = await _companyDomain.GetAll();
            var result = _mapper.Map<List<Company>, List<CompanyResponse>>(response);
            return result;
        }

        // GET: api/Company/5
        [HttpGet("{id}", Name = "GetCompanyById")]
        public async Task<CompanyResponse> GetById(int id)
        {
            var company = await _companyDomain.GetById(id);
            var response = _mapper.Map<Company, CompanyResponse>(company);
            return response;
        }
        // GET: api/Company/name
        [HttpGet("GetCompanyByName")]
        public async Task<List<CompanyResponse>> GetByName(string name)
        {
            Company company = new Company()
            {
                Name = name,
            };
            var companyByName = await _companyDomain.GetByName(company);
            var response = _mapper.Map<List<Company>, List<CompanyResponse>>(companyByName);
            return response;
        }
        
        // GET: api/Company/5
        [HttpGet("GetCompanyByRuc")]
        public async Task<List<CompanyResponse>> GetByRuc(string ruc)
        {
            Company company = new Company()
            {
                Ruc = ruc,
            };
            var companyByName = await _companyDomain.GetByRuc(company);
            var response = _mapper.Map<List<Company>, List<CompanyResponse>>(companyByName);
            return response;
        }
        // POST: api/Company
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompanyRequest companyRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var tourist = _mapper.Map<CompanyRequest, Company>(companyRequest);
                return Ok(await _companyDomain.Create(tourist));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CompanyRequest companyRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var tourist = _mapper.Map<CompanyRequest, Company>(companyRequest);
                return Ok(await _companyDomain.Update(tourist, id));
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
            return await _companyDomain.Delete(id);
        }
        // Agrega este método a tu clase CompanyController
        
        
        
        // Agrega este método a tu clase CompanyController
        [HttpGet("representative/{representativeId}")]
        public async Task<List<CompanyResponse>> GetByRepresentativeId(int representativeId)
        {
            var companies = await _companyDomain.GetByRepresentativeId(representativeId);
            var response = _mapper.Map<List<Company>, List<CompanyResponse>>(companies);
            return response;
        }

    }
    
   

}
