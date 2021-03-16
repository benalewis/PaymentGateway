using NSubstitute;
using NUnit.Framework;
using PaymentGateway.BankAPI;
using PaymentGateway.BankAPI.Models;
using PaymentGateway.Core.Models;
using PaymentGateway.Core.Validators;
using PaymentGateway.DataAccess;
using PaymentGateway.Services;
using PaymentGateway.Tests.Helpers;
using System;
using PaymentRequest = PaymentGateway.Core.API.PaymentRequest;

namespace PaymentGateway.Tests.Unit
{
    [TestFixture]
    public class PaymentServiceTests
    {
        private readonly IPaymentService _sut;

        private readonly IPaymentRepository _paymentRepository = Substitute.For<IPaymentRepository>();
        private readonly IBankService _bankService = Substitute.For<IBankService>();
        private readonly IPaymentRequestValidator _paymentRequestValidator = Substitute.For<IPaymentRequestValidator>();

        public PaymentServiceTests()
        {
            _sut = new PaymentService(_paymentRepository, _bankService, _paymentRequestValidator);
        }

        [Test]
        public void CanGet()
        {
            // Act
            _sut.Get(RandomHelper.GetRandomString(5));

            // Assert
            _paymentRepository.Received(1).Get(Arg.Any<string>());
        }

        [Test]
        public void CanMakePayment()
        {
            // Arrange
            _bankService.MakePayment(Arg.Any<BankAPI.Models.PaymentRequest>())
                .Returns(new PaymentResponse(RandomHelper.GetRandomString(16), BankResult.Success));

            // Act
            _sut.MakeRequest(new PaymentRequest
            {
                Amount = 100,
                CardNumber = RandomHelper.GetRandomString(16),
                CardVerificationValue = RandomHelper.GetRandomString(3),
                CurrencyCode = "GBP",
                ExpiryDate = DateTime.Now.AddYears(2)
            });

            // Assert
            _paymentRepository.Received(1).Get(Arg.Any<string>());

            _bankService.Received(1).MakePayment(Arg.Any<BankAPI.Models.PaymentRequest>());
            _paymentRepository.Received(1).Store(Arg.Any<Payment>());
        }
    }
}

