using AutoMapper;
using Data.Model;
using UniqueTrip.Request;
using UniqueTrip.Response;

namespace UniqueTrip.Mapper;

public class ModelToResource : Profile
{
    public ModelToResource()
    {
        CreateMap<Representante, RepresentanteRequest>();
        CreateMap<Representante, RepresentanteResponse>();
    }
    
}