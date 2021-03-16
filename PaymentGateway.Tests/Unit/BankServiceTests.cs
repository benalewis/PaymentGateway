using NUnit.Framework;
using PaymentGateway.BankAPI;
using PaymentGateway.BankAPI.Models;
using PaymentGateway.Tests.Helpers.BankAPI;
using PaymentGateway.Tests.Helpers.BankAPI.Interfaces;

namespace PaymentGateway.Tests.Unit
{
    [TestFixture]
    public class BankServiceTests
    {
        private readonly IBankService _sut;

        private IPaymentRequestBuilder PaymentRequestBuilder { get; } = new PaymentRequestBuilder();

        public BankServiceTests()
        {
            _sut = new BankService();
        }

        [Test(Description = "Make a successful payment request.")]
        public void CanMakePayment()
        {
            // Arrange
            var request = PaymentRequestBuilder.WithRealisticValues().Build();

            // Act
            var result = _sut.MakePayment(request);

            // Assert
            Assert.NotNull(result.Guid);
            Assert.AreEqual(BankResult.Success, result.BankResult);
        }

        [Test(Description = "Assert that we can simulate a failed response.")]
        public void CanReceiveFailedResponse()
        {
            // Arrange
            var request = PaymentRequestBuilder.WithRealisticValues().WithCardNumber("FAILURE").Build();

            // Act
            var result = _sut.MakePayment(request);

            // Assert
            Assert.AreEqual(BankResult.Failure, result.BankResult);
        }
    }
}