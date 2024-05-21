using AutoMapper;
using StorageAccounting.Contracts.Models.Arrival;
using StorageAccounting.Contracts.Requests.Arrival;
using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Application.Profiles;
public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<ArrivalRow, ArrivalRowDto>()
            .ForMember(
                x => x.ProductTypeMarkId, 
                opt => opt.MapFrom(x => x.Mark.ProductTypeMarks.Where(pm => pm.ProductTypeId == x.Position.Item.ProductTypeId).Single().Id));

        CreateMap<Arrival, ArrivalDto>()
            .ForMember(x => x.PlaceName, opt => opt.MapFrom(x => x.Place.Name))
            .ForMember(x => x.PartnerName, opt => opt.MapFrom(x => x.Partner.Name));

        CreateMap<ArrivalRowCreateRequest, ArrivalRow>();

        CreateMap<ArrivalCreateRequest, Arrival>();
    }
}
