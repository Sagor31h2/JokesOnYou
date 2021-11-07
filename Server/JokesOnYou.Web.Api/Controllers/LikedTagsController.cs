﻿using JokesOnYou.Web.Api.Extensions;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Response;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Registered,Admin")]
    public class LikedTagsController : ControllerBase
    {
        private readonly ILikedTagsService _likedTagsService;

        public LikedTagsController(ILikedTagsService likedTagsService)
        {
            _likedTagsService = likedTagsService;
        }
        
        [HttpPost]
        [Route("LikeTag")]
        public async Task<ActionResult<LikedTagsReplyDto>> LikeTagAsync(int tagID)
        {
            var userId = ClaimsPrincipalExtension.GetUserId(User);
            var tagDto = await _likedTagsService.LikeTagAsync(tagID, userId);
            return tagDto;
        }

        [HttpPost]
        [Route("UnlikeTag")]
        public async Task<ActionResult> UnlikeTagAsync(int tagID)
        {
            var userId = ClaimsPrincipalExtension.GetUserId(User);
            await _likedTagsService.UnlikeTagAsync(tagID, userId);
            return NoContent();
        }

    }
}
