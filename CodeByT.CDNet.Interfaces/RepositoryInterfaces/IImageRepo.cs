using CodeByT.CDNet.Models.Data_Models;

namespace CodeByT.CDNet.Interfaces.RepositoryInterfaces;

public interface IImageRepo
{
    public void AddImage(StoredImage storedImage);
    public StoredImage? GetImageById(Guid id);
    public void RemoveImage(Guid id);
}