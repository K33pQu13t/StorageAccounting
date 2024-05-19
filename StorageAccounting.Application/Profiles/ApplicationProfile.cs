using AutoMapper;
using StorageAccounting.Contracts.Models.Arrival;
using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Application.Profiles;
public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Arrival, ArrivalDto>()
            .ForMember(x => x.PlaceName, opt => opt.MapFrom(x => x.Place.Name))
            .ForMember(x => x.PartnerName, opt => opt.MapFrom(x => x.Partner.Name));
    }
}
