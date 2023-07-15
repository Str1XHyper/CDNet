using CodeByT.CDNet.Models.Data_Models;
using Microsoft.EntityFrameworkCore;

namespace CodeByT.CDNet.DataAccess;

public static class ModelMapping
{
    public static void MapImages(this ModelBuilder builder)
    {
        builder.Entity<Image>(e =>
        {
            e.ToTable("Images");
            e.HasKey(p => p.id);
            e.Property(p => p.base64);
            e.Property(p => p.contentType);
            e.Property(p => p.fileName);
        });
    }
}