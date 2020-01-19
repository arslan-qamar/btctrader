# BTC Trader API Integration 

This project is C# integration with BTC Market V3 API. It has integration with Account , Market , Order , Trade and MarketFeed Api endpoints. Most of the endpoints are integrated and this code base can be further extended to implement your program based trading strategies. Logging support is included with Serilog.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Steps to get development running.

1. Create an appsettings.json file in Root folder of the project by copying content of appsettings.TXT file.
2. Add API Key and Private Key for your BTCMarket account.
3. Run the unit tests and Integration tests.
4. Run BTCTrader project to see the Feed of market emitted to console output.
5. Extend to your trading strategy and Happy Trading.

### Prerequisites

The project uses .net core 3.1. SDK and that is pretty much what is required to get started.

```
.Net Core 3.1 
Your favourite IDE for coding. (I use Visual Studio Community Edition)
```

## Running the tests

You can run tests for this project using following options

```
dotnet test
using Testrunner in Visual Studio
```

### Types of Tests

There are two types of tests in Tests Folder. Xunit framework is used for writing these types of tests. (In future i plan to add BDD tests too)

1. Integration tests
```
The integration tests work with real api endpoint and do api contract validation.
All integration test classes inherit from ServiceTestsBase which uses TradingSystem Fixture that initialize all the dependencies per TestClass this helps in reduced code for each integration test (avoiding repeated Arrange section), this makes writing integration test easier by following DRY principle.
Some integration tests need to be run in sequence rather than parallel. e.g CancelAllOrders and AddOrder test cannot run in parallel. Xunit test collections are used to control to execution of such tests. 
```

2. Unit tests
```
The unit tests work by mocking dependencies and are mostly to test basic logics in code.
```

## Built With

* [.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) - The framework used
* [XUnit](https://xunit.net/) - Testing Framework for Unit and Integration Tests
* [Serilog](https://serilog.net) - Logging Framework used throughout the project provides multi-color output on errors and warnings.

## Contributing

Happy to share the code base if someone is interested. Just ping.

## Authors

* **Arslan Qamar** - *https://www.linkedin.com/in/arslanqamar/*

See also the list of [contributors](https://github.com/arslan-qamar/btctrader/contributors) who participated in this project.

## License

This project is licensed under the MIT License.

## Acknowledgments

* BTCMarket sample C# code https://github.com/BTCMarkets/api-v3-client-dotnet
* Inspiration Earn Money ;) 
* Have Fun Trade Responsibly
