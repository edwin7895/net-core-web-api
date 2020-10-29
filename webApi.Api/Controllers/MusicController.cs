using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using webApi.Core.Services;
using webApi.Api.Resources;
using webApi.Core.Models;

namespace webApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;
        public MusicController(IMusicService musicService, IMapper mapper)
        {
            this._musicService = musicService;
            this._mapper = mapper;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<MusicResource>>> GetAllMusics(){
            var musics = await _musicService.GetAllWithArtist();
            var musicResources = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicResource>>(musics);
            return Ok(musicResources);
        }
    } 
}