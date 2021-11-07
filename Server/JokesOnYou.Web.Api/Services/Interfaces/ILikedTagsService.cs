﻿using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Response;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface ILikedTagsService
    {
        Task<LikedTagsReplyDto> LikeTagAsync(int tagID, string userId);
        Task UnlikeTagAsync(int tagID, string userId);
    }
}
