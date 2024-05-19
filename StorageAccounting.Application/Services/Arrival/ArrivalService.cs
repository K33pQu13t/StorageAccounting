using AutoMapper;
using StorageAccounting.Application.Interfaces.Services.Arrival;
using StorageAccounting.Contracts.Filters;
using StorageAccounting.Contracts.Models.Arrival;
using StorageAccounting.Domain.Contexts;

namespace StorageAccounting.Application.Services.Arrival;
public class ArrivalService : IArrivalService
{
    private readonly IMapper _mapper;

    private readonly StorageAccountingContext _context;

    public ArrivalService(IMapper mapper, StorageAccountingContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public double Create()
    {
        throw new NotImplementedException();
    }

    public ArrivalDto Get(double id)
    {
        // TODO: project to?
        Domain.Models.Storage.Arrival? arrival = _context.Arrivals
            .Where(arrival => arrival.Id == id)
            .SingleOrDefault()
            ?? throw new ApplicationException("Документ поступления не найден");

        ArrivalDto arrivalDto = _mapper.Map<ArrivalDto>(arrival);

        return arrivalDto;
    }

    public List<ArrivalDto> Get(ArrivalFilter filter)
    {
        throw new NotImplementedException();
    }
}
