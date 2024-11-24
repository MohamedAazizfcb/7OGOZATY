using Domain.Constants;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Utility
{
    public class FileHandler
    {
        public static async Task<string> UploadAsync(IFormFile file, string uploadDir)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File cannot be null or empty", nameof(file));

            var fileExtension = Path.GetExtension(file.FileName);
            var uniqueFileName = $"{DateTime.Now:yyyyMMddHHmmss}{fileExtension}";
            var path = Path.Combine(uploadDir, uniqueFileName);
            EnsureDirectoryExists(uploadDir);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while uploading the file.", ex);
            }

            return uniqueFileName;
        }

        public static void Delete(string filePath)
        {
            if (Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Error while deleting the file: {filePath}", ex);
                }
            }
        }

        public static bool Move(string fileName, string fromDir, string toDir)
        {
            var sourcePath = Path.Combine(fromDir, fileName);
            var destPath = Path.Combine(toDir, fileName);

            if (!Exists(sourcePath) || Exists(destPath)) return false;

            EnsureDirectoryExists(toDir);

            try
            {
                File.Move(sourcePath, destPath);
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error while moving the file: {fileName}", ex);
            }
        }

        public static bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }

        public static string GetFile(string fileName)
        {
            var files = Directory.GetFiles(AppConstants.wwwroot, fileName, SearchOption.AllDirectories);

            return files.FirstOrDefault();
        }

        private static void EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                try
                {
                    Directory.CreateDirectory(directoryPath);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Error while creating directory: {directoryPath}", ex);
                }
            }
        }
    }
}
