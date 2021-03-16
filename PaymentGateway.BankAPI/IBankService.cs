using PaymentGateway.BankAPI.Models;

namespace PaymentGateway.BankAPI
{
    public interface IBankService
    {
        /// <summary>
        /// Creates a payment request.
        /// </summary>
        PaymentResponse MakePayment(PaymentRequest request);
    }
}
