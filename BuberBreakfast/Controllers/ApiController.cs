using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController: ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        var FirstError = errors[0];

        var statusCode = FirstError.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => 400,
            _ => 500
        };
    }
}