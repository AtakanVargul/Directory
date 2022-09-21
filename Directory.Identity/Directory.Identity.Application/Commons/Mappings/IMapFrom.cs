using AutoMapper;

namespace Directory.Identity.Application.Commons.Mappings;

public interface IMapFrom<T>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType()).ReverseMap();
    }
}