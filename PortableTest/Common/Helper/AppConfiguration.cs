using System.IO;
using Microsoft.Extensions.Configuration;

public static class AppConfiguration
{
    public static IConfiguration GetConfiguration()
    {
        var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").AddEnvironmentVariables();
        return configurationBuilder.Build();
    }
}