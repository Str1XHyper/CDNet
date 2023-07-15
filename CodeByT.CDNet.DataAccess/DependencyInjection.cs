using CodeByT.CDNet.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeByT.CDNet.DataAccess;

public class DependencyInjection
{
    public static void UseScope(IServiceScope scope)
    {
        var dataContext = scope.ServiceProvider.GetRequiredService<DefaultContext>();
        dataContext.Database.Migrate();
    }
}