using PaymentGateway.Core.API;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentGateway.Core.Validators
{
    public interface IPaymentRequestValidator
    {
        void Validate(PaymentRequest payment);
    }

    public class PaymentRequestValidator : IPaymentRequestValidator
    {
        public void Validate(PaymentRequest payment)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(payment.CardVerificationValue))
            {
                errors.Add("Card number was null or empty");
            }

            if (string.IsNullOrWhiteSpace(payment.CardVerificationValue))
            {
                errors.Add("CVV was null or empty");
            }

            if (errors.Any())
            {
                throw new ArgumentException($"{nameof(PaymentRequest)} was invalid. Errors: {string.Join(", ", errors)}.");
            }
        }
    }
}
