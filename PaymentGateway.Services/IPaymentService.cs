using PaymentGateway.Core;
using PaymentGateway.Core.API;
using PaymentGateway.Core.Models;

namespace PaymentGateway.Services
{
    public interface IPaymentService
    {
        Payment Get(string identifier);
        PaymentResult MakeRequest(PaymentRequest request);
    }
}
