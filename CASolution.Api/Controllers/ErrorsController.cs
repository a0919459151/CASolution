using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CASolution.Api.Controllers;

[ApiController]
[Route("error")]
public class ErrorsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem(
            detail: exception?.StackTrace,
            title: exception?.Message);
    }
}
