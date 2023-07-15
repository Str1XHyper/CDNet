using CodeByT.CDNet.Interfaces.DataAccessInterfaces.Contexts;
using CodeByT.CDNet.Models.Data_Models;
using Microsoft.EntityFrameworkCore;

namespace CodeByT.CDNet.DataAccess.Contexts;

public class DefaultContext : DbContext, IDefaultContext
{
    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Define mapping here
        builder.MapImages();
        
        // Define seeding here
        // new TemplateSeeding().Init(builder);
    }

    public DbSet<Image> Images { get; set; }
}