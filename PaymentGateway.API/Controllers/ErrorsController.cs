using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Net;

namespace PaymentGateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            Logger.Error(exception, $"An error has occurred: {exception.Message}.");

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return BadRequest($"An error has occurred: {exception.Message}, please try again and if the problem persists contact support.");
        }
    }
}
