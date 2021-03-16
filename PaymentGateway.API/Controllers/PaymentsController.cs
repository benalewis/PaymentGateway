using Microsoft.AspNetCore.Mvc;
using NLog;
using PaymentGateway.Common;
using PaymentGateway.Core.API;
using PaymentGateway.Services;
using System.Threading.Tasks;

namespace PaymentGateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentRequest request)
        {
            Logger.Info($"{nameof(Post)} request received for {request.CardNumber.Obfuscate(4)}.");
            return Ok(_paymentService.MakeRequest(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Logger.Info($"{nameof(Get)} request received for {id}.");
            return Ok(_paymentService.Get(id));
        }
    }
}
