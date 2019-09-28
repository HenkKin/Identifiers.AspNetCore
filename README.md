Identifiers.AspNetCore
======================
[![NuGet](https://img.shields.io/nuget/dt/Identifiers.AspNetCore.svg)](https://www.nuget.org/packages/Identifiers.AspNetCore) 
[![NuGet](https://img.shields.io/nuget/vpre/Identifiers.AspNetCore.svg)](https://www.nuget.org/packages/Identifiers.AspNetCore)

### Summary

The Identifiers.AspNetCore library is an extensions on [Identifiers](https://github.com/HenkKin/Identifiers/).

This library is Cross-platform, supporting `netstandard2.1`.


### Installing Identifiers.AspNetCore

You should install [Identifiers.AspNetCore with NuGet](https://www.nuget.org/packages/Identifiers.AspNetCore):

    Install-Package Identifiers.AspNetCore

Or via the .NET Core command line interface:

    dotnet add package Identifiers.AspNetCore

Either commands, from Package Manager Console or .NET Core CLI, will download and install Identifiers.AspNetCoreand all required dependencies:
- [Identifiers](https://www.nuget.org/packages/Identifiers/)
- [Microsoft.AspNetCore.Mvc.NewtonsoftJson](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/)

### Usage

To use it:

```csharp
using Identifiers;

public class Order
{
    public Identifier Id { get; set; }
    ...
```

### ASP.NET Core

If you're using ASP.NET Core and you want to use this Identifier type in your models, then you can use [Identifiers.AspNetCore](https://github.com/HenkKin/Identifiers.AspNetCore/) package which includes a `IServiceCollection.AddIdentifiers<[InternalClrType:short|int|long|Guid]>()` extension method, allowing you to register all needed RouteConstraints, ModelBinders and JsonConverters.

### EntityFrameworkCore

If you're using EntityFrameworkCore and you want to use this Identifier type in your entities, then you can use [Identifiers.EntityFrameworkCore](https://github.com/HenkKin/Identifiers.EntityFrameworkCore/) package which includes a `DbContextOptionsBuilder.UseIdentifiers<[InternalClrType:short|int|long|Guid]>()` extension method, allowing you to register all needed IValueConverterSelectors and IMigrationsAnnotationProviders. 
It also includes a `PropertyBuilder<Identifier>.IdentifierValueGeneratedOnAdd()` extension method, allowing you to register all needed configuration to use SqlServerValueGenerationStrategy.IdentityColumn. 
