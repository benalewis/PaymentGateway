using PaymentGateway.Core.Models;
using System.Collections.Generic;

namespace PaymentGateway.DataAccess
{
    /// <summary>
    /// An in-memory context.
    /// </summary>
    public class PaymentGatewayContext
    {
        public List<Payment> Payments = new List<Payment>();
    }
}
