using AutoMapper;
using CNX.Contracts.DTO;
using CNX.Contracts.DTO.Response;
using CNX.Contracts.Entities;

namespace CNX.Configs
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //user
            CreateMap<UserModel, UserDto>();
            CreateMap<UserDto, UserModel>();
            CreateMap<UserModel, NewUserAddedResponseDto>();

            //note
            CreateMap<NoteDto, NoteModel>();
            CreateMap<NoteModel, NoteDto>();

            //password
            CreateMap<PasswordResetModel, PasswordResetDto>();
            CreateMap<PasswordResetDto, PasswordResetModel>();

        }
    }
}
