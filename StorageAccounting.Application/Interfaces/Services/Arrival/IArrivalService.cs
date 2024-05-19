using StorageAccounting.Contracts.Filters;
using StorageAccounting.Contracts.Models.Arrival;

namespace StorageAccounting.Application.Interfaces.Services.Arrival;

public interface IArrivalService
{
    public ArrivalDto Get(double id);

    public List<ArrivalDto> Get(ArrivalFilter filter);

    public double Create();
}
