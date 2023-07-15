using CodeByT.CDNet.Models.Data_Models;

namespace CodeByT.CDNet.Interfaces.RepositoryInterfaces;

public interface IImageRepo
{
    public void AddImage(Image image);
    public Image? GetImageById(Guid id);
}