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
    [Route("api/v1/[controller]")]
    public class ImagesController : Controller
    {
        private readonly IImagesData _imagesData;
        private readonly IImagesDomain _imagesDomain;
        private readonly IMapper _mapper;
        
        public ImagesController(IImagesData imagesData, IImagesDomain imagesDomain, IMapper mapper)
        {
            _imagesData = imagesData;
            _imagesDomain = imagesDomain;
            _mapper = mapper;
        }
        
        [HttpGet("all")]
        public async Task<List<ImagesResponse>> GetAll()
        {
            var response = await _imagesData.GetAll();
            var result = _mapper.Map<List<Images>, List<ImagesResponse>>(response);
            return result;
        }

        [HttpGet("id/{id}")]
        public async Task<ImagesResponse> GetById(int id)
        {
            var response = await _imagesData.GetById(id);
            var result = _mapper.Map<Images, ImagesResponse>(response);
            return result;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ImagesRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var image = _mapper.Map<ImagesRequest, Images>(request);

            var result = await _imagesDomain.AddImage(image);

            if (result.IsSuccess)
            {
                return Created($"/api/v1/images/{result.Data.Id}", result.Data);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpPut("id/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ImagesRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = _mapper.Map<ImagesRequest, Images>(request);
                return Ok(await _imagesDomain.Update(result, id));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("id/{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _imagesDomain.Delete(id);
        }
    }
}