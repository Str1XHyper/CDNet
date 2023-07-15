using Microsoft.Extensions.DependencyInjection;

namespace CodeByT.CDNet.DependencyInjection.Extensions;

public static class ScopesExtensions
{
    public static void ExtendScopes(this IServiceScope scope)
    {
        DataAccess.DependencyInjection.UseScope(scope);
    }
}