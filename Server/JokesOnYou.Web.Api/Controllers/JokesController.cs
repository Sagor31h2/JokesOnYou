using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Extensions;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JokesController : ControllerBase
    {
        private readonly IJokesService _jokesService;

        public JokesController(IJokesService jokesService)
        {
            _jokesService = jokesService;
        }

        [Authorize(Roles = "Registered,Admin")]
        [HttpPost]
        public async Task<ActionResult<JokeReplyDto>> CreateJokeAsync(JokeCreateDto jokeCreateDto)
        {

            jokeCreateDto.UserId = ClaimsPrincipalExtension.GetUserId(User);
            var jokeReplyDto = await _jokesService.CreateJokeAsync(jokeCreateDto);

            return jokeReplyDto;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JokeReplyDto>>> GetAllJokesAsync()
        {
            var jokeDtos = await _jokesService.GetAllJokeDtosAsync();
            return Ok(jokeDtos);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJoke(int id)
        {
            await _jokesService.RemoveJokeAsync(id);
            return NoContent();
        }
        
        [HttpPut]
        public async Task<ActionResult<JokeReplyDto>> UpdateJoke(JokeUpdateDto jokeUpdateDto)
        {
            var jokeReplyDto = await _jokesService.UpdateJoke(jokeUpdateDto);
            return jokeReplyDto;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<JokeReplyDto>> GetJoke(int id)
        {
            var joke = await _jokesService.GetJokeDtoAsync(id);
            return joke;
        }

    }
}
