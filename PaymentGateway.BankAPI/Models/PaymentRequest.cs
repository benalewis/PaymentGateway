using System;

namespace PaymentGateway.BankAPI.Models
{
    public class PaymentRequest
    {
        public string CardNumber { get; }
        public DateTime ExpiryDate { get; }
        public decimal Amount { get; }
        public string CurrencyCode { get; }
        public string CardVerificationValue { get; }

        public PaymentRequest(string cardNumber, DateTime expiryDate, decimal amount, string currencyCode, string cardVerificationValue)
        {
            CardNumber = cardNumber;
            ExpiryDate = expiryDate;
            Amount = amount;
            CurrencyCode = currencyCode;
            CardVerificationValue = cardVerificationValue;
        }
    }
}
