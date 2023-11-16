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
    [Route("api/v1/Comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentDomain _commentDomain;
        private readonly ICommentData _commentData;
        private readonly IMapper _mapper;
        
        public CommentController(ICommentDomain commentDomain, ICommentData commentData, IMapper mapper)
        {
            _commentDomain = commentDomain;
            _commentData = commentData;
            _mapper = mapper;
        }
        // GET: api/Activities
        [HttpGet("all")]
        public async Task<List<CommentResponse>> GetAll()
        {
            var response = await _commentData.GetAll();
            var result = _mapper.Map<List<Comment>, List<CommentResponse>>(response);
            return result;
        }

        // GET: api/Activities/5
        [HttpGet("id/{id}")]
        public async Task<CommentResponse> GetById(int id)
        {
            var response = await _commentData.GetById(id);
            var result = _mapper.Map<Comment, CommentResponse>(response);
            return result;
        }

        // GET: api/Activities/title
        [HttpGet("title/{title}")]
        public async Task<List<CommentResponse>> GetByContent(string content)
        {
            Comment initial = new Comment()
            {
                Content = content,
            };
            var response = await _commentData.GetByContent(initial);
            var result = _mapper.Map<List<Comment>, List<CommentResponse>>(response);
            return result;
        }
        // POST: api/Activities
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentRequest commentRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = _mapper.Map<CommentRequest, Comment>(commentRequest);
                return Ok(await _commentDomain.Create(result));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Activities/5
        [HttpPut("id/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CommentRequest commentRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = _mapper.Map<CommentRequest, Comment>(commentRequest);
                return Ok(await _commentDomain.Update(result, id));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Activities/5
        [HttpDelete("id/{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _commentDomain.Delete(id);
        }

    }
}
