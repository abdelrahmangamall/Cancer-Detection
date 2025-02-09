namespace Domain_Layer.Models
{
    public class CTScan
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ImagePath { get; set; }
        public DateTime UploadDate { get; set; }
    }

}
