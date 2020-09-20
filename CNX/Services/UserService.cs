using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using CNX.Contracts.DTO;
using CNX.Contracts.Entities;
using CNX.Contracts.Interfaces;

namespace CNX.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDto GetByParameters(string username)
        {
            return _mapper.Map<UserDto>(_userRepository.GetByParameters(username).FirstOrDefault());
        }
    }
}
