using Newtonsoft.Json;

namespace Infrastructure.Utility
{
    public static class MimeTypes
    {
        // immutability with a fallback to an empty dictionary
        private static readonly IReadOnlyDictionary<string, string> mimeTypes;

        static MimeTypes()
        {
            try
            {
                string json = File.ReadAllText("MimeTypes.json");
                mimeTypes = JsonConvert.DeserializeObject<IReadOnlyDictionary<string, string>>(json) ?? new Dictionary<string, string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading mime types: {ex.Message}");
                mimeTypes = new Dictionary<string, string>();
            }
        }

        public static string GetMimeType(string extension)
        {
            if (string.IsNullOrWhiteSpace(extension)) return null!;

            extension = extension.TrimStart('.').ToLower();

            // Use TryGetValue for efficient lookup
            mimeTypes.TryGetValue(extension, out var mimeType);
            return mimeType;
        }

        public static IReadOnlyDictionary<string, string> AllMimeTypes => mimeTypes;
    }
}
