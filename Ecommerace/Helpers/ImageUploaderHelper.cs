namespace Ecommerace.Helpers
{
    public static class ImageUploaderHelper
    {
        public static string upload(IFormFile file , IWebHostEnvironment webHostEnvironment)
        {
            string file_name = $"{Guid.NewGuid().ToString()}_{file.FileName}";
            string folder = $"/images/{file_name}";
            string path = webHostEnvironment.WebRootPath.Replace("\\", "/") + folder;
            file.CopyToAsync(new FileStream(path, FileMode.Create));
            return file_name ;
        }
    }
}
    