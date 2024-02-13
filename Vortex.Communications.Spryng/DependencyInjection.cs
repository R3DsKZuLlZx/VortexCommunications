using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Vortex.Communications.Spryng;

public static class DependencyInjection
{
    public static IServiceCollection AddSpryng(
        this IServiceCollection serviceCollection,
        string token)
        => serviceCollection.AddSpryng(token, httpBuilder: null);

    public static IServiceCollection AddSpryng(
        this IServiceCollection serviceCollection,
        string token,
        Action<IHttpClientBuilder>? httpBuilder)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(token);
        
        return serviceCollection
            .AddSingleton(Options.Create(new SpryngApiOptions(token)))
            .AddSpryngClients(httpBuilder);
    }
    
    public static IServiceCollection AddSpryng(
        this IServiceCollection serviceCollection,
        SpryngApiOptions options)
        => serviceCollection.AddSpryng(options, httpBuilder: null);

    public static IServiceCollection AddSpryng(
        this IServiceCollection serviceCollection,
        SpryngApiOptions options,
        Action<IHttpClientBuilder>? httpBuilder)
        => serviceCollection
            .AddSingleton(Options.Create(options))
            .AddSpryngClients(httpBuilder);

    public static IServiceCollection AddSpryng(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        string sectionName = nameof(SpryngApiOptions))
        => serviceCollection.AddSpryng(configuration, httpBuilder: null, sectionName);

    public static IServiceCollection AddSpryng(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        Action<IHttpClientBuilder>? httpBuilder,
        string sectionName = nameof(SpryngApiOptions))
        => serviceCollection
            .AddOptions<SpryngApiOptions>()
            .Bind(configuration.GetSection(sectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart()
            .Services
            .AddSpryngClients(httpBuilder);

    private static IServiceCollection AddSpryngClients(
        this IServiceCollection serviceCollection,
        Action<IHttpClientBuilder>? httpBuilderCallback)
    {
        var httpBuilder = serviceCollection
            .AddSingleton(s => s.GetRequiredService<IOptions<SpryngApiOptions>>().Value)
            .AddHttpClient<ISpryngApiClient, SpryngApiClient>();

        httpBuilderCallback?.Invoke(httpBuilder);

        return serviceCollection;
    }
}
