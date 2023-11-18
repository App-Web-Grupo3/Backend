using AutoMapper;
using Data.Model;

namespace Domain.Mapper;

public class UserBaseTo : Profile
{
    public UserBaseTo()
    {
        CreateMap<UserBase, Tourist>();
        CreateMap<UserBase, Representative>();
    }

}