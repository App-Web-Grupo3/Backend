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
        private readonly IMapper _mapper;
        
        public CommentController(ICommentDomain commentDomain, IMapper mapper)
        {
            _commentDomain = commentDomain;
            _mapper = mapper;
        }
        // GET: api/Response
        [HttpGet("GetAllComments")]
        public async Task<List<CommentResponse>> GetAll()
        {
            var response = await _commentDomain.GetAll();
            var result = _mapper.Map<List<Comment>, List<CommentResponse>>(response);
            return result;
        }

        // GET: api/Company/5
        [HttpGet("{id}", Name = "GetCommentById")]
        public async Task<CommentResponse> GetById(int id)
        {
            var comment = await _commentDomain.GetById(id);
            var response = _mapper.Map<Comment, CommentResponse>(comment);
            return response;
        }
        // GET: api/Company/name
        [HttpGet("GetCommentByContent")]
        public async Task<List<CommentResponse>> GetByContent(string content)
        {
            Comment comment = new Comment()
            {
                Content = content,
            };
            var commentByContent = await _commentDomain.GetByContent(comment);
            var response = _mapper.Map<List<Comment>, List<CommentResponse>>(commentByContent);
            return response;
        }
        
        // POST: api/Company
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentRequest commentRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var tourist = _mapper.Map<CommentRequest, Comment>(commentRequest);
                return Ok(await _commentDomain.Create(tourist));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CommentRequest commentRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var tourist = _mapper.Map<CommentRequest, Comment>(commentRequest);
                return Ok(await _commentDomain.Update(tourist, id));
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
            return await _commentDomain.Delete(id);
        }
    }
}
