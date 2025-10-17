using AutoMapper;
using NotificationFeatureProject.Models;

namespace NotificationFeatureProject.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Pet, Pet>().ForMember(x => x.Id, option => option.Ignore());
    }
}