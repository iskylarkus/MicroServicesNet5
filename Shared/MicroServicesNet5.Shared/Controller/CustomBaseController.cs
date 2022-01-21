using MicroServicesNet5.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MicroServicesNet5.Shared.Controller
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.Status
            };
        }
    }
}
