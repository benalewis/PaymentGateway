using PaymentGateway.BankAPI.Models;
using PaymentGateway.Tests.Helpers.BankAPI.Interfaces;
using System;

namespace PaymentGateway.Tests.Helpers.BankAPI
{
    public class PaymentRequestBuilder : IPaymentRequestBuilder
    {
        private string CardNumber { get; set; }
        private DateTime ExpiryDate { get; set; }
        private decimal Amount { get; set; }
        private string CurrencyCode { get; set; }
        private string CardVerificationValue { get; set; }

        public PaymentRequest Build()
        {
            return new PaymentRequest(CardNumber, ExpiryDate, Amount, CurrencyCode, CardVerificationValue);
        }

        public IPaymentRequestBuilder WithRealisticValues()
        {
            WithExpiryDate(DateTime.Now.AddYears(2))
                .WithCardNumber(RandomHelper.GetRandomString(16))
                .WithAmount(100)
                .WithCurrencyCode("GBP")
                .WithCardVerificationValue(RandomHelper.GetRandomString(3));

            return this;
        }

        public IPaymentRequestBuilder WithCardNumber(string cardNumber)
        {
            CardNumber = cardNumber;
            return this;
        }

        public IPaymentRequestBuilder WithExpiryDate(DateTime expiryDate)
        {
            ExpiryDate = expiryDate;
            return this;
        }

        public IPaymentRequestBuilder WithAmount(decimal amount)
        {
            Amount = amount;
            return this;
        }

        public IPaymentRequestBuilder WithCurrencyCode(string currencyCode)
        {
            CurrencyCode = currencyCode;
            return this;
        }

        public IPaymentRequestBuilder WithCardVerificationValue(string ccv)
        {
            CardVerificationValue = ccv;
            return this;
        }
    }
}
