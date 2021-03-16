using PaymentGateway.Core.Models;

namespace PaymentGateway.Core.API
{
    public class PaymentResult
    {
        public string Id { get; set; }
        public PaymentStatusCode Result { get; set; }
    }
}
