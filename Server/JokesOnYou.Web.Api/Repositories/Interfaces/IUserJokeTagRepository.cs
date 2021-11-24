﻿using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Request;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface IUserJokeTagRepository
    {
        Task CreateUserJokeTagAsync(UserJokeTag userJokeTag);
        Task<UserJokeTag> GetUserJokeTagAsync(UserJokeTag userJokeTag);
        Task<UserJokeTag> GetUSerJokeTagAsync(int id);
    }
}
