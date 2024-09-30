using Microsoft.AspNetCore.Http;

namespace CodeByT.CDNet.Models.Data_Models;

public class StoredImage
{
    public StoredImage()
    {
    }

    public StoredImage(string base64, string contentType, string fileName)
    {
        Id = Guid.NewGuid();
        ContentType = contentType;
        FileName = fileName;
        Base64 = base64;
    }

    public StoredImage(IFormFile image)
    {
        Id = Guid.NewGuid();
        ContentType = image.ContentType;
        FileName = image.FileName;
        using var reader = image.OpenReadStream();
        byte[] buffer = new byte[reader.Length];
        reader.Read(buffer, 0, (int)reader.Length);
        Base64 = Convert.ToBase64String(buffer);
    }

    public string Base64 { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
    public Guid Id { get; set; }
}