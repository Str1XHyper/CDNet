

using CodeByT.CDNet.Models.Data_Models;
using Microsoft.EntityFrameworkCore;

namespace CodeByT.CDNet.Interfaces.DataAccessInterfaces.Contexts;

public interface IDefaultContext : IDbContext
{
    public DbSet<Image> Images { get; set; }
}