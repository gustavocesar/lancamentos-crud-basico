using CrudLancamentos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CrudLancamentos.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected ActionResult CustomResponse(ResultBase response)
    {
        if (response is Responses.NotFoundResult)
            return NotFound(response);

        if (response is Responses.InvalidResult)
            return BadRequest(response);

        return Ok(response);
    }
}
