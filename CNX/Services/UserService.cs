using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using AutoMapper;
using CNX.Contracts.DTO;
using CNX.Contracts.DTO.Response;
using CNX.Contracts.Entities;
using CNX.Contracts.Interfaces;
using CNX.Repositories;
using CNX.Utils;

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

        public UserDto GetById(int id)
        {
            var user = _userRepository.GetById(id);
            
            DecryptNotes(user.Notes);

            return _mapper.Map<UserModel, UserDto>(user);
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDto GetByEmail(string email)
        {
            var user = _userRepository.GetByEmail(email);

            return _mapper.Map<UserModel, UserDto>(user);

        }

        public async Task<NewUserAddedResponseDto> Create(UserDto dto)
        {
            var errors = dto.ValidateFields();

            if (errors.Count > 0)
                throw new ArgumentException(string.Join(".",errors));

            var model = _mapper.Map<UserDto, UserModel>(dto);

            EncryptData(model);

            var result = await _userRepository.CreateAsync(model);

            DecryptNotes(model.Notes);
            return _mapper.Map<UserModel, NewUserAddedResponseDto>(result);
        }

        private void DecryptNotes(List<NoteModel> modelNotes)
        {
            modelNotes.ForEach(x =>
            {
                x.Content = EncryptionUtil.Decrypt(x.Content);
            });
        }

        private static void EncryptData(UserModel model)
        {
            model.Password = EncryptionUtil.Encrypt(model.Password);
            model.Notes.ForEach(x =>
            {
                x.Content = EncryptionUtil.Encrypt(x.Content);
            });
        }
    }
}
