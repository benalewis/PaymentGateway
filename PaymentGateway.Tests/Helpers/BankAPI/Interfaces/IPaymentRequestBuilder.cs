using PaymentGateway.BankAPI.Models;
using System;

namespace PaymentGateway.Tests.Helpers.BankAPI.Interfaces
{
    public interface IPaymentRequestBuilder
    {
        PaymentRequest Build();
        IPaymentRequestBuilder WithRealisticValues();
        IPaymentRequestBuilder WithCardNumber(string cardNumber);
        IPaymentRequestBuilder WithExpiryDate(DateTime expiryDate);
        IPaymentRequestBuilder WithAmount(decimal amount);
        IPaymentRequestBuilder WithCurrencyCode(string currencyCode);
        IPaymentRequestBuilder WithCardVerificationValue(string ccv);
    }
}