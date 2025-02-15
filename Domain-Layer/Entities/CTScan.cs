namespace Domain_Layer.Models
{
    public class CTScan
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }          // Link to the user
        public string FileName { get; set; }       // Original file name
        public string StoredFileName { get; set; } // Unique filename on the server
        public long FileSize { get; set; }         // File size in bytes
        public string ContentType { get; set; }    // MIME type (e.g., "image/jpeg")
        public string FilePath { get; set; }       // Full path to the saved image
        public DateTime UploadDate { get; set; }   // Upload timestamp
        public int? Width { get; set; }            // Image width (optional)
        public int? Height { get; set; }           // Image height (optional)
    }

}
