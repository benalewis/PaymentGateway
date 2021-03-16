using NUnit.Framework;
using PaymentGateway.Core.API;
using PaymentGateway.Core.Validators;
using PaymentGateway.Tests.Helpers;
using System;

namespace PaymentGateway.Tests.Unit.Validators
{
    [TestFixture]
    public class PaymentRequestValidatorTests
    {
        private IPaymentRequestValidator _sut;

        public PaymentRequestValidatorTests()
        {
            _sut = new PaymentRequestValidator();
        }

        [Test(Description = "Validates successfully (no error returned).")]
        public void CanValidate()
        {
            // Act
            _sut.Validate(new PaymentRequest
            {
                Amount = 100,
                CardNumber = RandomHelper.GetRandomString(16),
                CardVerificationValue = RandomHelper.GetRandomString(3),
                CurrencyCode = "GBP",
                ExpiryDate = DateTime.Now.AddYears(2)
            });

            // Assert
            Assert.True(true, "This test is deemed a pass if no exception is thrown.");
        }

        [Test(Description = "Validates, an exception should be thrown.")]
        public void CanValidateIncorrectData()
        {
            // Act
            var exception = Assert.Throws<ArgumentException>(() => _sut.Validate(new PaymentRequest()));

            // Assert
            Assert.AreEqual("PaymentRequest was invalid. Errors: Card number was null or empty, CVV was null or empty.", exception.Message);
        }
    }
}