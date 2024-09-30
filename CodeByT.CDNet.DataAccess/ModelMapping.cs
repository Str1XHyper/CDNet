using CodeByT.CDNet.Models.Data_Models;
using Microsoft.EntityFrameworkCore;

namespace CodeByT.CDNet.DataAccess;

public static class ModelMapping
{
    public static void MapImages(this ModelBuilder builder)
    {
        builder.Entity<StoredImage>(e =>
        {
            e.ToTable("Images");
            e.HasKey(p => p.Id);
            e.Property(p => p.Base64);
            e.Property(p => p.ContentType);
            e.Property(p => p.FileName);
        });
    }
}