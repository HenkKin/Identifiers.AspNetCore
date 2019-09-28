Identifiers.AspNetCore
======================
[![Build Status](https://ci.appveyor.com/api/projects/status/github/HenkKin/Identifiers.AspNetCore?branch=master&svg=true)](https://ci.appveyor.com/project/HenkKin/Identifiers.AspNetCore) 
[![NuGet](https://img.shields.io/nuget/dt/Identifiers.AspNetCore.svg)](https://www.nuget.org/packages/Identifiers.AspNetCore) 
[![NuGet](https://img.shields.io/nuget/vpre/Identifiers.AspNetCore.svg)](https://www.nuget.org/packages/Identifiers.AspNetCore)

### Summary

The Identifiers.AspNetCore library is an extension on [Identifiers](https://github.com/HenkKin/Identifiers/).

This library is Cross-platform, supporting `netstandard2.1`.


### Installing Identifiers.AspNetCore

You should install [Identifiers.AspNetCore with NuGet](https://www.nuget.org/packages/Identifiers.AspNetCore):

    Install-Package Identifiers.AspNetCore

Or via the .NET Core command line interface:

    dotnet add package Identifiers.AspNetCore

Either commands, from Package Manager Console or .NET Core CLI, will download and install Identifiers.AspNetCore and all required dependencies.

### Dependencies

- [Identifiers](https://www.nuget.org/packages/Identifiers/)
- [Microsoft.AspNetCore.Mvc.NewtonsoftJson](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/)

### Usage

If you're using ASP.NET Core and you want to use this Identifier type in your models, then you can use [Identifiers.AspNetCore](https://github.com/HenkKin/Identifiers.AspNetCore/) package which includes a `IServiceCollection.AddIdentifiers<[InternalClrType:short|int|long|Guid]>()` extension method, allowing you to register all needed RouteConstraints, ModelBinders and JsonConverters.

To use it:

```csharp
...
using Identifiers.AspNetCore;

public class Startup
{
    ...
    
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddIdentifiers<short|int|long|Guid>();
        ...
    }
    
    ...
```

### Using NSwag

If you're using [NSwag](https://github.com/RicoSuter/NSwag/) and you want to use this `Identifier` type in your models. Then you have to choose how to expose your `Identifier` types. Below an example if you want to expose your `Identifier` type as `string`:

```csharp
...
using Identifiers;

public class Startup
{
    ...
    
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddSwaggerDocument(settings =>
        {
            settings.Title = "Your Service";
            ...
            settings.TypeMappers.Add(new PrimitiveTypeMapper(typeof(Identifier), s => s.Type = JsonObjectType.String));
        });
        ...
    }
    
    ...
```


