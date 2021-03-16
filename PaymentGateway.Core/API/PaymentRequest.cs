using System;

namespace PaymentGateway.Core.API
{
    public class PaymentRequest
    {
        public string CardNumber { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Amount { get; set; }
        public string CardVerificationValue { get; set; }
    }
}
