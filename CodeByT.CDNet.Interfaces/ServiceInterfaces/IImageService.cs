
using CodeByT.CDNet.Models.Data_Models;
using Microsoft.AspNetCore.Http;

namespace CodeByT.CDNet.Interfaces.ServiceInterfaces;

public interface IImageService
{
    StoredImage? GetImageByID(Guid id);
    void DeleteImageById(Guid id);
    string UploadImage(IFormFile image, bool cropped, int height, int width);
}