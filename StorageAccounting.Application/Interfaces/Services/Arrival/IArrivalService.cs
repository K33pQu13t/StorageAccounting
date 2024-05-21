using StorageAccounting.Contracts.Filters.Arrival;
using StorageAccounting.Contracts.Models.Arrival;
using StorageAccounting.Contracts.Requests.Arrival;

namespace StorageAccounting.Application.Interfaces.Services.Arrival;

public interface IArrivalService
{
    public ArrivalDto Get(long id);

    public List<ArrivalDto> Get(ArrivalFilter filter);

    public long Create(ArrivalCreateRequest request);
}
