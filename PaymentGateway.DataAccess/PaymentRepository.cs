using NLog;
using PaymentGateway.Core.Models;
using System;
using System.Linq;

namespace PaymentGateway.DataAccess
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentGatewayContext _context;
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public PaymentRepository(PaymentGatewayContext context)
        {
            _context = context;
        }

        public void Store(Payment payment)
        {
            Logger.Debug($"{nameof(Store)} request received for {payment.MaskedCardNumber}.");
            _context.Payments.Add(payment);
        }

        public Payment Get(string identifier)
        {
            Logger.Debug($"{nameof(Get)} request received for {identifier}.");
            var result = _context.Payments.SingleOrDefault(x => x.Identifier == identifier);

            if (result == null)
                throw new InvalidOperationException($"Could not find a {nameof(Payment)} with the identifier {identifier}.");

            return result;
        }
    }
}
