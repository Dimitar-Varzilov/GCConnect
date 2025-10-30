// GCConnect.Services/Mapping/Profiles/UsersProfile.cs
using AutoMapper;
using GCConnect.Common.Entities;
using GCConnect.Common.DTOs.Users;

public sealed class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<User, UserSummaryDto>();
        CreateMap<User, UserDetailsDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<AdminUpdateUserDto, User>();
    }
}
