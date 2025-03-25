namespace Domain_Layer.Models
{
    public class CTScan
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }     
        public string StoredFileName { get; set; }
        public long FileSize { get; set; }       
        public string ContentType { get; set; }  
        public string FilePath { get; set; }     
        public DateTime UploadDate { get; set; } 
        public int? Width { get; set; }          
        public int? Height { get; set; }         
    }

}
