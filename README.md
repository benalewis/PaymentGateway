# PaymentGateway .NET Challenge
This solution provides my submission for the PaymentGateway .NET challenge.

It aims to satisfy the deliverables:
* Build an API that allows a merchant
  * To process a payment through your payment gateway.
  * To retrieve details of a previously made payment.
* Build a simulator to mock the responses from the bank to test the API from your first deliverable.

To demonstrate the above: download, run and build the API.

To make a payment request POST to https://localhost:5001/api/payments
To retrieve a payment request https://localhost:5001/api/payments/{guid} (where the guid is the payment's identifier).

The shape of the json for the POST is:

```
{
  "cardNumber": null,
  "currencyCode": null,
  "expiryDate": "0001-01-01T00:00:00",
  "amount": 0.0,
  "cardVerificationValue": null
}
```

There are suitable tests to mock the Bank API. 

There is no storage for this solution, it is all in memory. 

Overall I spent about 2 hours on this solution to build a barebones submission that satisfied the requirements in a simple and lean manner.

## Improvements

* Add end-to-end tests (and more tests in general).
  * There are some tests in the solution but no E2E tests and no memory tests.
* Add security 
  * I would have liked to see some authentication/authorization.
* Add idempotency 
  * Idempotency is a key part of payment requests, would have ideally like to have implemented a layer here to avoid duplicate requests.
* Add caching
  * Caching speeds up systems and reduces database load, a no brainer.
* Add permanent data storage
  * Would have liked to see a database here so that the data we create isn't wiped every time but for a pilot system in-memory is fine.
* Implement async
  * Usually an API would be asynchronous, would help with blocking.
