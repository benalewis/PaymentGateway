namespace PaymentGateway.BankAPI.Models
{
    public class PaymentResponse
    {
        public string Guid { get; }
        public BankResult BankResult { get; }

        public PaymentResponse(string guid, BankResult bankResult)
        {
            Guid = guid;
            BankResult = bankResult;
        }
    }
}
