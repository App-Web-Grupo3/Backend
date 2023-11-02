using AutoMapper;
using Data.Model;
using UniqueTrip.Request;

namespace UniqueTrip.Mapper;

public class ResourceToModel : Profile
{
    public ResourceToModel()
    {
        CreateMap<RepresentanteRequest, Representante>();
        CreateMap<TouristRequest, Tourist>();
        CreateMap<ResponseRequest, Answer>();
        CreateMap<CompanyRequest, Company>();
        CreateMap<FavoritesRequest, Favorites>();
    }
}