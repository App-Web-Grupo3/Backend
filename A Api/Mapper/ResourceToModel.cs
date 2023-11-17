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
        CreateMap<ActivitiesRequest, Activities>();
        CreateMap<ImagesRequest, Images>();
        
        CreateMap<FavoritesRequest, Answer>();
        CreateMap<PaymentMethodRequest, PaymentMethod>();
        CreateMap<PaymentRequest, Payment>();
    }
}