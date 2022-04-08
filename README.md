# TrueLayer.NET

The branch is to demonstrate a proof of concept done on contract testing done using pactflow  - with Payment Gateway as Provider and Payment UX (Backend SDK) as consumer.


The consumer will run the contract test to generate the pact file which will be shared to the provider via pact broker or locally.


API Tested - Create Payment to merchant account using HPP

```
POST /payments
```

## Installation

Refer steps [here](https://github.com/TrueLayer/truelayer-dotnet/blob/main/README.md) to set up the project locally

## Prereqsuites

####Without pactbroker

1. The test create the pact based on the test in "ConsumerPactTest.cs" under Truelayer.AcceptanceTests
2. The test emulates the expected behavior against a mock server which is recorded by pact tool to generate the contratc
3. Comment the pactPublisher method in the "ConsumerPactClassFixture.cs" to stop the publish to pactbroker
4. After running the test it should generate a local pact file under /pacts

####With pactbroker

1. Get a PactBroker account, so you can access to your local [pactbroker](https://pactflow.io/try-for-free/?utm_source=homepage&utm_content=header) server
2. Follow the sign up process, and get your base url and access key.
3. Set the variables PACT_BROKER_BASEURL, PACT_BROKER_TOKEN in your system variable(zshrc/bash) files.
4. Download the SSL certificates and bundle it as .pem and reference the path to the same at SSL_CERT_FILE variable. This enables publishing contracts.Read [here](https://github.com/pact-foundation/pact-js/issues/203)
   (Ensure to keep your netscope enabled)
5. On running the same test pact will be published to the pact broker

### Contract Tests -With Pact File

```
cd test/Truelayer.AcceptanceTests
dotnet test --filter "TrueLayer.AcceptanceTests.ConsumerPactTests.MakeValidPayment"

```
### Contract Tests -With Bidirectional Testing

[Bidirectional Testing](https://pactflow.io/bi-directional-contract-testing/) is a Static Test to compare the consumer pact with the OAS file.
1. There is a make file at the project root which helps publish the pact 
2. pactbroker is compulsory for bidirectional testing and the test very closely emulates the example from pact itself
3. In Makefile the path to SSL certificate needs to be updated <PATH_TO_CERT_FILE_ON_HOST> to your local file path. Refer details here [Using a custom certificate](https://hub.docker.com/r/pactfoundation/pact-cli)
```
make fake_ci
```
### References
1. [pact-net](https://github.com/pact-foundation/pact-net/releases)
2. [pact-net-git](https://github.com/pact-foundation/pact-net/tree/release/3.x)
3. [pact-bidirectional-git](https://github.com/pactflow/example-bi-directional-provider-dotnet)
4. [Documentation](https://docs.pactflow.io)
5. Setting [pactbroker](https://github.com/pact-foundation/pact_broker) on your own premises

