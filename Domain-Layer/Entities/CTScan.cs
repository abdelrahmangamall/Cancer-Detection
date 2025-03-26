﻿namespace Domain_Layer.Models
{
    public class CTScan
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }     
        public string FilePath { get; set; }     
        public DateTime UploadDate { get; set; } 
      
        public PredictionResult PredictionResult { get; set; }
    }

}
