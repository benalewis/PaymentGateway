using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.BankAPI;
using PaymentGateway.Core.Validators;
using PaymentGateway.DataAccess;
using PaymentGateway.Services;

namespace PaymentGateway.API
{
    public static class DependencyInjection
    {
        public static void RegisterDependencies(IServiceCollection collection)
        {
            collection.AddScoped<IPaymentRepository, PaymentRepository>();
            collection.AddScoped<IPaymentService, PaymentService>();
            collection.AddScoped<IBankService, BankService>();
            collection.AddSingleton<IPaymentRequestValidator, PaymentRequestValidator>();
            collection.AddSingleton<PaymentGatewayContext>();
        }
    }
}
