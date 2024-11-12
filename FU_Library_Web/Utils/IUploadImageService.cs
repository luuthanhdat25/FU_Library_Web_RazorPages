namespace FU_Library_Web.Utils
{
    public interface IUploadImageService
    {
        Task<string> UploadImage(IFormFile File);
    }
}
