using AutoMapper;
using Data.Model;
using UniqueTrip.Request;
using UniqueTrip.Response;

namespace UniqueTrip.Mapper;

public class ModelToResource : Profile
{
    public ModelToResource()
    {
        CreateMap<Representative, RepresentativeRequest>();
        CreateMap<Representative, RepresentativeResponse>();
        CreateMap<Tourist, TouristRequest>();
        CreateMap<Tourist, TouristResponse>();
        CreateMap<Answer, ResponseRequest>();
        CreateMap<Answer, ResResponse>();
        CreateMap<Company, CompanyRequest>();
        CreateMap<Company, CompanyResponse>();
        CreateMap<Activities, ActivitiesRequest>();
        CreateMap<Activities, ActivitiesResponse>();
        CreateMap<Images, ImagesRequest>();
        CreateMap<Images, ImagesResponse>();
        CreateMap<Favorites, FavoritesRequest>();
        CreateMap<Favorites, FavoritesResponse>();
        CreateMap<PaymentMethod, PaymentMethodRequest>();
        CreateMap<PaymentMethod, PaymentMethodResponse>();
        CreateMap<UserBase, UserRegisterRequest>();
        CreateMap<UserBase, UserLoginRequest>();
        CreateMap<UserBase, UserResponse>();
        
        CreateMap<PurchaseDetail, PurchaseDetailRequest>();
        CreateMap<PurchaseDetail, PurchaseDetailResponse>();
        CreateMap<Comment, CommentRequest>();
        CreateMap<Comment, CommentResponse>();
    }
    
}