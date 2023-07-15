using Microsoft.AspNetCore.Http;

namespace CodeByT.CDNet.Models.Data_Models;

public class Image
{
    public Image()
    {
    }

    public Image(IFormFile image)
    {
        id = Guid.NewGuid();
        contentType = image.ContentType;
        fileName = image.FileName;
        using var reader = image.OpenReadStream();
        byte[] buffer = new byte[reader.Length];
        reader.Read(buffer, 0, (int)reader.Length);
        base64 = Convert.ToBase64String(buffer);
    }

    public string base64 { get; set; }
    public string contentType { get; set; }
    public string fileName { get; set; }
    public Guid id { get; set; }
}