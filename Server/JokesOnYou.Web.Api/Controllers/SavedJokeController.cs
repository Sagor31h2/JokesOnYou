﻿using JokesOnYou.Web.Api.Extensions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Response;
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
    public class SavedJokeController : ControllerBase
    {
        private readonly ISavedJokeService _savedJokeService;

        public SavedJokeController(ISavedJokeService savedJokeService)
        {
            _savedJokeService = savedJokeService;
        }
        [HttpPost("{id}")]
        public async Task<ActionResult> ToggleSavedJoke(int id)//id here is jokeid
        {
            await _savedJokeService.ToggleSavedJoke(id, ClaimsPrincipalExtension.GetUserId(User));
            return NoContent();
        }
        [HttpGet]
        public ActionResult<IAsyncEnumerable<Joke>> GetSavedJokesByUserId()
        {
            var jokes = _savedJokeService.GetSavedJokesByUserId(ClaimsPrincipalExtension.GetUserId(User));
            return Ok(jokes);
        }
    }
}