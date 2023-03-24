using Microsoft.AspNetCore.Http;

namespace MottoAdver.Application.Services;
public static class ImagesService
{
    private static readonly string folderPath;

    static ImagesService()
    {
        folderPath = Path.Join(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);
    }
    public static string SaveImage(
        ICollection<IFormFile> formFiles,
        string newsGuid,
        string langCode)
    {
        string filePath = "";

        if (formFiles.Count() > 0)
        {
            int i = 1;
            foreach(var file in formFiles)
            {
                filePath = Path.Combine(folderPath, newsGuid + langCode + $"{i++}.jpg");

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }
            }
        }
        return filePath;
    }
}
