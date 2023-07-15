using CodeByT.CDNet.Interfaces.ServiceInterfaces;
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
    public IActionResult UploadImage(IFormFile image)
    {
        var uri = _imageService.UploadImage(image);
        return Created(uri, null);
    }
    
    [HttpGet]
    public IActionResult GetImageById(Guid id)
    {
        var image = _imageService.GetImageByID(id);
        //TODO Add custom http exceptions
        if (image is null) return NotFound();
        var imageBytes = Convert.FromBase64String(image.base64);
        return File(imageBytes, image.contentType);
    }
}