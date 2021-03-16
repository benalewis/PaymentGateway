using PaymentGateway.BankAPI.Models;
using PaymentGateway.Core.API;
using PaymentGateway.Core.Models;
using System;

namespace PaymentGateway.Services.Mappers
{
    public static class BankApi
    {
        public static PaymentStatusCode ToPaymentStatusCode(this BankResult bankResult)
        {
            return bankResult switch
            {
                BankResult.Failure => PaymentStatusCode.Failure,
                BankResult.Success => PaymentStatusCode.Success,
                _ => throw new ArgumentOutOfRangeException(nameof(bankResult), bankResult, null)
            };
        }

        public static BankAPI.Models.PaymentRequest ToBankApi(this Core.API.PaymentRequest request)
        {
            return new BankAPI.Models.PaymentRequest(request.CardNumber, request.ExpiryDate, request.Amount, request.CurrencyCode, request.CardVerificationValue);
        }

        public static PaymentResult ToApiModel(this PaymentResponse response)
        {
            var statusCode = response.BankResult switch
            {
                BankResult.Failure => PaymentStatusCode.Failure,
                BankResult.Success => PaymentStatusCode.Success,
                _ => throw new ArgumentOutOfRangeException($"{response.BankResult} not supported!")
            };

            return new PaymentResult
            {
                Id = response.Guid,
                Result = statusCode
            };
        }
    }
}
