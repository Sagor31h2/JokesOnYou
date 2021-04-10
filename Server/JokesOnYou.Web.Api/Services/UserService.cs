﻿using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Exceptions;

namespace JokesOnYou.Web.Api.Services
{
    
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepo;
        public  UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<IEnumerable<UserReplyDTO>> GetAll()
        {
            return await _userRepo.GetUsersAsync();
        }
        public async Task<User> CreateUser(UserRegisterDTO registerDTO)
        {
            return await _userRepo.CreateUserAsync(registerDTO);
        }
        
        public async Task DeleteUser(string id)
        {
            var user = await _userRepo.GetUserAsync(id);
            if (user == null)
                throw new AppException($"Cant find user of id:{id}");
            await _userRepo.DeleteUserAsync(user);
        }

        public async Task<UserReplyDTO> GetUserReplyById(string id)
        {
            return await _userRepo.GetUserReplyAsync(id);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepo.UpdateUser(user); 
        }

        public async Task<User> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
