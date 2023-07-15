
using CodeByT.CDNet.Models.Data_Models;
using Microsoft.AspNetCore.Http;

namespace CodeByT.CDNet.Interfaces.ServiceInterfaces;

public interface IImageService
{
    public string UploadImage(IFormFile image);
    public Image? GetImageByID(Guid id);
}