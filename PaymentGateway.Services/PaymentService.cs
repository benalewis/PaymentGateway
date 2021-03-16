using NLog;
using PaymentGateway.BankAPI;
using PaymentGateway.Common;
using PaymentGateway.Core.API;
using PaymentGateway.Core.Models;
using PaymentGateway.Core.Validators;
using PaymentGateway.DataAccess;
using PaymentGateway.Services.Mappers;
using System;
using PaymentRequest = PaymentGateway.Core.API.PaymentRequest;

namespace PaymentGateway.Services
{
    public class PaymentService : IPaymentService
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private readonly IPaymentRepository _paymentRepository;
        private readonly IBankService _bankService;
        private readonly IPaymentRequestValidator _requestValidator;

        public PaymentService(IPaymentRepository repository, IBankService bankService, IPaymentRequestValidator validator)
        {
            _paymentRepository = repository;
            _bankService = bankService;
            _requestValidator = validator;
        }

        public Payment Get(string identifier)
        {
            Logger.Info($"{nameof(Get)} request received for {identifier}.");
            return _paymentRepository.Get(identifier);
        }

        public PaymentResult MakeRequest(PaymentRequest request)
        {
            if (request == null)
                throw new ArgumentException($"{nameof(PaymentRequest)} was null.");

            Logger.Info($"{nameof(MakeRequest)} received for {request.CardNumber.Obfuscate(4)}.");

            _requestValidator.Validate(request);

            var result = _bankService.MakePayment(request.ToBankApi());

            _paymentRepository.Store(new Payment(
                result.Guid,
                request.CardNumber.Obfuscate(4),
                request.Amount,
                request.ExpiryDate,
                request.CurrencyCode,
                result.BankResult.ToPaymentStatusCode(),
                DateTime.Now));

            return result.ToApiModel();
        }
    }
}
