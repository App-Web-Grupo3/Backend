using AutoMapper;
using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;
using Microsoft.AspNetCore.Mvc;
using UniqueTrip.Request;
using UniqueTrip.Response;


namespace UniqueTrip.Controllers
{
    [Route("api/v1/Favorites")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesDomain _favoritesDomain;
        private readonly IFavoritesData _favoritesData;
        private readonly IMapper _mapper;

        public FavoritesController(IFavoritesDomain favoritesDomain, IFavoritesData favoritesData, IMapper mapper)
        {
            _favoritesDomain = favoritesDomain;
            _favoritesData = favoritesData;
            _mapper = mapper;
        }

        // GET: api/Favorites
        [HttpGet("GetAll")]
        public async Task<List<FavoritesResponse>> GetAll()
        {
            var favorites = await _favoritesData.GetAll();
            var response = _mapper.Map<List<Favorites>, List<FavoritesResponse>>(favorites);
            return response;
        }

        // GET: api/Favorites/5
        [HttpGet("{id}")]
        public async Task<FavoritesResponse> GetById(int id)
        {
            var favorites = await _favoritesData.GetById(id);
            var response = _mapper.Map<Favorites, FavoritesResponse>(favorites);
            return response;
        }

        // POST: api/Favorites
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FavoritesRequest favoritesRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var favorites = _mapper.Map<FavoritesRequest, Favorites>(favoritesRequest);
                return Ok(await _favoritesDomain.Create(favorites));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Favorites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FavoritesRequest favoritesRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var favorites = _mapper.Map<FavoritesRequest, Favorites>(favoritesRequest);
                return Ok(await _favoritesDomain.Update(favorites, id));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Favorites/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _favoritesDomain.Delete(id);
        }
    }
}
