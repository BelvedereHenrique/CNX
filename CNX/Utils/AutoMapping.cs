using AutoMapper;
using CNX.Contracts.DTO;
using CNX.Contracts.Entities;

namespace CNX.Utils
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserDto>();
        }
    }
}
