using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Crud.AssetManagement.Utils
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult FromResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest(result.Error);
        }

        protected IActionResult FromResult<T>(T result)
        {
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
