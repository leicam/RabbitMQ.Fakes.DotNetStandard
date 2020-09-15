__NOTE:__ This repo is a fork of [Parametric/RabbitMQ.Fakes](https://github.com/Parametric/RabbitMQ.Fakes). __RabbitMQ.Fakes__ is a .NET Framework 4.5 library, whereas __RabbitMQ.Fakes.DotNetStandard__ is the .NET Standard 2.0 version of __RabbitMQ.Fakes__.

# RabbitMQ.Fakes.DotNetStandard
RabbitMQ.Fakes.DotNetStandard is a .NET Standard 2.0 library that contains fake implementations of the RabbitMQ.Client interfaces.  These are intended to be used for testing so that unit tests who depend on RabbitMQ can be executed fully in memory withouth the dependence on an external RabbitMQ server.

# Requirements
* .NET Core 2.0 OR .NET Framework 4.6.1 ([though you should probably use .NET Framework 4.7.2](https://docs.microsoft.com/en-us/dotnet/standard/net-standard))
* Nuget Package Manger

# Projects
* __RabbitMQ.Fakes.DotNetStandard:__ Implementation of the fakes in .NET Standard 2.0
* __RabbitMQ.Fakes.DotNetCoreTests:__ Unit tests around the fake implementation using .NET Core 3.1

# Fakes
* __RabbitServer:__ In memory representation of a RabbitMQ server.  This is where the Exchanges / Queues / Bindings / Messages are held.
* __FakeConnectionFactory:__ Fake implementation of the RabbitMQ `IConnectionFactory`.  Returns a `FakeConnection` when the `CreateConnection()` method is called
* __FakeConnection:__ Fake implementation of the RabbitMQ `IConnection`.  Returns a FakeModel when the `CreateModel()` method is called
* __FakeModel:__ Fake implementation of the RabbitMQ `IModel`.  Interacts with the `RabbitServer` instance passed into the `FakeConnectionFactory`.

# Sample Usage
See the UseCases in the RabbitMQ.Fakes.DotNetCoreTests project for sample usage
