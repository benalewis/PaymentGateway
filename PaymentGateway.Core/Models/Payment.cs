using System;

namespace PaymentGateway.Core.Models
{
    public class Payment
    {
        public string Identifier { get; }
        public string MaskedCardNumber { get; }
        public decimal Amount { get; }
        public DateTime ExpiryDate { get; }
        public string CurrencyCode { get; }
        public PaymentStatusCode StatusCode { get; }
        public DateTime AddedDate { get; set; }

        public Payment(string identifier, string maskedCardNumber, decimal amount, DateTime expiryDate, string currencyCode, PaymentStatusCode statusCode, DateTime addedDate)
        {
            Identifier = identifier;
            MaskedCardNumber = maskedCardNumber;
            Amount = amount;
            ExpiryDate = expiryDate;
            CurrencyCode = currencyCode;
            StatusCode = statusCode;
            AddedDate = addedDate;
        }
    }
}
