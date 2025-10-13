using Microsoft.AspNetCore.StaticAssets;

namespace NotificationFeatureProject.Extensions;

public static class EnvironmentVariableExtension
{
    public static string GetConnectionStringFromEnvironmentVariable(this IConfiguration configuration, string name = null!)
    {
        if (string.IsNullOrEmpty(name))
            return Environment.GetEnvironmentVariable("ConnectionStrings_NotificationFeatureProject")!;

        return Environment.GetEnvironmentVariable(name)!;
    }
}