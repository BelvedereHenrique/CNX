using AutoMapper;
using CNX.Contracts.DTO;
using CNX.Contracts.DTO.Response;
using CNX.Contracts.Entities;

namespace CNX.Utils
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserModel, UserDto>();
            CreateMap<UserDto, UserModel>();
            CreateMap<NoteDto, NoteModel>();
            CreateMap<NoteModel, NoteDto>();
            CreateMap<UserModel, NewUserAddedResponseDto>();
        }
    }
}
