using PaymentGateway.Core.Models;

namespace PaymentGateway.DataAccess
{
    public interface IPaymentRepository
    {
        void Store(Payment payment);
        Payment Get(string identifier);
    }
}
