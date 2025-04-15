﻿using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? applicationUser = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

            if (applicationUser == null)
            {
                return null;
            }

            return _mapper.Map<AuthenticationResponse>(applicationUser) with { Success = true, Token = "token" };
        }


        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            ApplicationUser user = new ApplicationUser
            {
                PersonName = registerRequest.PersonName,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Gender = registerRequest.Gender.ToString(),
            };
            ApplicationUser? registerUser = await _userRepository.AddUser(user);

            if (registerUser == null)
            {
                return null;
            }

            return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
        }
    }
}
