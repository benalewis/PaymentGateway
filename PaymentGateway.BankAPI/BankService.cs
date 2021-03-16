using NLog;
using PaymentGateway.BankAPI.Models;
using PaymentGateway.Common;
using System;

namespace PaymentGateway.BankAPI
{
    public class BankService : IBankService
    {
        private static ILogger Logger { get; } = LogManager.GetCurrentClassLogger();

        public PaymentResponse MakePayment(PaymentRequest request)
        {
            Logger.Info($"{nameof(MakePayment)} request received for {request.CardNumber.Obfuscate(4)}.");

            return request.CardNumber == "FAILURE" ? new PaymentResponse(Guid.NewGuid().ToString(), BankResult.Failure) : new PaymentResponse(Guid.NewGuid().ToString(), BankResult.Success);
        }
    }
}
