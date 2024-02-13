# Vortex Spryng Integration

[![Nuget](https://img.shields.io/nuget/v/Vortex.Communications.Spryng?label=NuGet)](https://www.nuget.org/packages/Vortex.Communications.Spryng)
[![Nuget](https://img.shields.io/nuget/dt/Vortex.Communications.Spryng?label=Downloads)](https://www.nuget.org/packages/Vortex.Communications.Spryng)

The goal of this package is to expose the Spryng API as a simple to use package.

If you find this project useful, please give it a star. Thanks! ⭐

## Getting Started

The easiest way to get started is to install the [package](https://www.nuget.org/packages/Vortex.Communications.Spryng):
```
dotnet add package Vortex.Communications.Spryng
```

Adding the Spryng client using a token:
```csharp
services.AddSpryng("YourToken");
```

Adding the Spryng client using `IConfiguration`:
```csharp
services.AddSpryng(configuration, "YourSectionName");
```

App settings:
```json
{
  "YourSectionName": {
    "Token": "YourToken",
    "BaseAddress": "SpryngBaseAddress"
  }
}
```

Once the client is configured, you can inject the `ISpryngApiClient` into your class through the constructor.
```csharp
public class ExampleClass
{
    private readonly ISpryngApiClient _client;
    
    public ExampleClass(ISpryngApiClient client)
    {
        _client = client;
    }

    public async Task ExampleMethod()
    {
        var request = new SendSmsRequest
        {
            Body = "Some Message!",
            Originator = "Test",
            Recipients = ["+447000000000"],
        };
        
        var response = await _client.SendSms(request, CancellationToken.None);
    }   
}
```

## Technologies

* [ASP.NET Core 8](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
* [Spryng](https://docs.spryngsms.com/)

## Support

If you are having problems, please let me know by raising a new issue.

## License

Feel free to do what you want.
