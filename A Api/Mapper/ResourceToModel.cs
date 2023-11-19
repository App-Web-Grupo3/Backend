using AutoMapper;
using Data.Model;
using UniqueTrip.Request;

namespace UniqueTrip.Mapper;

public class ResourceToModel : Profile
{
    public ResourceToModel()
    {
        CreateMap<RepresentativeRequest, Representative>();
        CreateMap<TouristRequest, Tourist>();
        CreateMap<ResponseRequest, Answer>();
        CreateMap<ActivitiesRequest, Activities>();
        CreateMap<CommentRequest, Activities>();
        CreateMap<CompanyRequest, Company>();
        CreateMap<ImagesRequest, Images>();
        CreateMap<FavoritesRequest, Favorites>();
        CreateMap<PaymentMethodRequest, PaymentMethod>();
        CreateMap<UserLoginRequest, UserBase>();
        CreateMap<UserRegisterRequest, UserBase>();
        
        CreateMap<PurchaseDetailRequest, PurchaseDetail>();
        CreateMap<CommentRequest, Comment>();
    }
}