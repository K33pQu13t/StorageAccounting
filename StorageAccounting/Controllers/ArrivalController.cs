using Microsoft.AspNetCore.Mvc;
using StorageAccounting.Application.Interfaces.Services.Arrival;
using StorageAccounting.Contracts.Models.Arrival;

namespace StorageAccounting.Web.Controllers;

[Route("api/[controller]")]
public class ArrivalController : ControllerBase
{
    private readonly IArrivalService _arrivalService;

    public ArrivalController(IArrivalService arrivalService)
    {
        _arrivalService = arrivalService;
    }

    [HttpGet("id")]
    public ActionResult<ArrivalDto> Get([FromRoute] double id)
    {
        ArrivalDto arrival = _arrivalService.Get(id);
        return Ok(arrival);
    }
}
