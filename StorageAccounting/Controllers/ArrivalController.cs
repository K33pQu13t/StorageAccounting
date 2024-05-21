using Microsoft.AspNetCore.Mvc;
using StorageAccounting.Application.Interfaces.Services.Arrival;
using StorageAccounting.Contracts.Models.Arrival;
using StorageAccounting.Contracts.Requests.Arrival;

namespace StorageAccounting.Web.Controllers;

[Route("api/[controller]/[action]")]
public class ArrivalController : ControllerBase
{
    private readonly IArrivalService _arrivalService;

    public ArrivalController(IArrivalService arrivalService)
    {
        _arrivalService = arrivalService;
    }

    [HttpGet("{id}")]
    public ActionResult<ArrivalDto> Get([FromRoute] long id)
    {
        ArrivalDto arrival = _arrivalService.Get(id);
        return Ok(arrival);
    }

    [HttpPost]
    public ActionResult<long> Create([FromBody] ArrivalCreateRequest request)
    {
        long id = _arrivalService.Create(request);
        return Ok(id);
    }
}
