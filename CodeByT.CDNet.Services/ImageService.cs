using CodeByT.CDNet.Interfaces.RepositoryInterfaces;
using CodeByT.CDNet.Interfaces.ServiceInterfaces;
using CodeByT.CDNet.Models.Data_Models;
using CodeByT.CDNet.Models.Enums;
using CodeByT.CDNet.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace CodeByT.CDNet.Services;

public class ImageService(IImageRepo imageRepo) : IImageService
{
    public string UploadImage(IFormFile formImage, bool cropped, int height, int width)
    {
        using var reader = formImage.OpenReadStream();
        try
        {
            using var image = Image.Load(reader);

            if (cropped)
            {
                var newWidth = Math.Min(image.Width, width);
                var newHeight = Math.Min(image.Height, height);


                image.Mutate(x => x.Crop(newWidth, newHeight));
            }
            else
            {
                var (orgWidth, orgHeight) = image.Size;
                if (orgWidth > width || orgHeight > height)
                {
                    var scaleWidth = width / (float)orgWidth;
                    var scaleHeight = height / (float)orgHeight;

                    var scale = Math.Min(scaleWidth, scaleHeight);

                    var newWidth = (int)(orgWidth * scale);
                    var newHeight = (int)(orgHeight * scale);

                    image.Mutate(x => x.Resize(newWidth, newHeight));
                }
            }

            var output = new MemoryStream();
            image.Save(output, new PngEncoder());

            output.Position = 0;

            var base64String = Convert.ToBase64String(output.ToArray());

            var storedImage = new StoredImage(base64String, "image/png", formImage.FileName);

            imageRepo.AddImage(storedImage);

            return "/image?id=" + storedImage.Id.ToString();
        }
        catch
        {
            throw new HttpResponseException(ExceptionType.BadRequest, "Given input isn't of an image type");
        }
    }

    public StoredImage? GetImageByID(Guid id) => imageRepo.GetImageById(id);

    public void DeleteImageById(Guid id)
    {
        var image = imageRepo.GetImageById(id);
        if (image is null) throw new HttpResponseException(ExceptionType.NotFound);

        imageRepo.RemoveImage(id);
    }
}