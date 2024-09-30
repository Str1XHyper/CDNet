using CodeByT.CDNet.Interfaces.ServiceInterfaces;
using CodeByT.CDNet.Models.Enums;
using CodeByT.CDNet.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CodeByT.CDNet.Controller.Controllers;

[ApiController]
[Route("image")]
public class ImageController : ControllerBase
{

    private readonly ILogger<ImageController> _logger;
    private readonly IImageService _imageService;

    public ImageController(
        ILogger<ImageController> logger,
        IImageService imageService)
    {
        _logger = logger;
        _imageService = imageService;
    }

    [HttpPost]
    [Route("upload")]
    public IActionResult UploadImage(IFormFile image, bool cropped, int height = 2160, int width = 3840)
    {
        var uri = _imageService.UploadImage(image, cropped, height, width);
        return Created(uri, null);
    }
    
    [HttpGet]
    public IActionResult GetImageById(Guid id)
    {
        var image = _imageService.GetImageByID(id);
        //TODO Add custom http exceptions
        if (image is null) throw new HttpResponseException(ExceptionType.NotFound);
        var imageBytes = Convert.FromBase64String(image.Base64);
        return File(imageBytes, image.ContentType);
    }

    [HttpDelete]
    public IActionResult DeleteImageById(Guid id)
    {
        _imageService.DeleteImageById(id);
        return Ok();
    }
}