using CodeByT.CDNet.Interfaces.DataAccessInterfaces.Contexts;
using CodeByT.CDNet.Interfaces.RepositoryInterfaces;
using CodeByT.CDNet.Models.Data_Models;

namespace CodeByT.CDNet.Repositories;

public class ImageRepo(IDefaultContext ctx) : IImageRepo
{
    public void AddImage(StoredImage storedImage)
    {
        ctx.Images.Add(storedImage);
        ctx.SaveChanges();
    }

    public StoredImage? GetImageById(Guid id) => ctx.Images.FirstOrDefault(i => i.Id == id);
    public void RemoveImage(Guid id)
    {
        ctx.Images.Remove(ctx.Images.FirstOrDefault(x => x.Id == id));
        ctx.SaveChanges();
    }
}