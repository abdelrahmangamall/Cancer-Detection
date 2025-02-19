﻿namespace Domain_Layer.Models
{
    public class PredictionResult
    {
        public Guid Id { get; set; }
        public Guid ScanId { get; set; }
        public string Prediction { get; set; } // "SCLC" or "NSCLC"
        public float Confidence { get; set; }
        public DateTime PredictionDate { get; set; }
    }
}
