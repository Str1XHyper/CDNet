using CodeByT.CDNet.Interfaces.DataAccessInterfaces.Contexts;
using CodeByT.CDNet.Interfaces.RepositoryInterfaces;
using CodeByT.CDNet.Models.Data_Models;

namespace CodeByT.CDNet.Repositories;

public class ImageRepo : IImageRepo
{
    private readonly IDefaultContext _ctx;

    public ImageRepo(IDefaultContext ctx)
    {
        _ctx = ctx;
    }

    public void AddImage(Image image)
    {
        _ctx.Images.Add(image);
        _ctx.SaveChanges();
    }

    public Image? GetImageById(Guid id) => _ctx.Images.FirstOrDefault(i => i.id == id);
}