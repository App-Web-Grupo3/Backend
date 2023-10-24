using AutoMapper;
using Data.Model;
using UniqueTrip.Request;

namespace UniqueTrip.Mapper;

public class ResourceToModel :Profile
{
    public ResourceToModel()
    {
        CreateMap<RepresentanteRequest, Representante>();
    }
}