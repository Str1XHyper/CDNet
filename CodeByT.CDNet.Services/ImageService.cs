

using CodeByT.CDNet.Interfaces.RepositoryInterfaces;
using CodeByT.CDNet.Interfaces.ServiceInterfaces;
using CodeByT.CDNet.Models.Data_Models;
using Microsoft.AspNetCore.Http;

namespace CodeByT.CDNet.Services;

public class ImageService: IImageService
{
    private readonly IImageRepo _imageRepo;

    public ImageService(IImageRepo imageRepo)
    {
        _imageRepo = imageRepo;
    }

    public string UploadImage(IFormFile formImage)
    {
        var image = new Image(formImage);
        
        _imageRepo.AddImage(image);

        return "/image?id=" + image.id.ToString();
    }

    public Image? GetImageByID(Guid id) => _imageRepo.GetImageById(id);
}