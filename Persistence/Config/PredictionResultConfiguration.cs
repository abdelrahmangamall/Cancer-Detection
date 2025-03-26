using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Persistence.Config
{
    public class PredictionResultConfiguration : IEntityTypeConfiguration<PredictionResult>
    {
        public void Configure(EntityTypeBuilder<PredictionResult> builder)
        {
            builder.ToTable("PredictionResults");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CTScanId)
                   .IsRequired();

            builder.Property(p => p.Prediction)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(p => p.Confidence)
                   .IsRequired();

            builder.Property(p => p.PredictionDate)
                   .IsRequired();

            builder.HasOne<CTScan>()
                   .WithOne(x=>x.PredictionResult)
                   .HasForeignKey<PredictionResult>(p => p.CTScanId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(LoadPredictionResults());
        }

        private static List<PredictionResult> LoadPredictionResults()
        {
            return new List<PredictionResult>
            {
                new PredictionResult
                {
                    Id =  Guid.Parse("7fa85f64-5717-4562-b3fc-2c963f66afa0"),
                    CTScanId = Guid.Parse("5fa85f64-5717-4562-b3fc-2c963f66afa8"),
                    Prediction = "NSCLC",
                    Confidence = 0.95f,
                    PredictionDate = new DateTime(2023, 10, 1)
                },
                new PredictionResult
                {
                    Id =  Guid.Parse("7fa85f64-5717-4562-b3fc-2c963f66afc9"),
                    CTScanId = Guid.Parse("6fa85f64-5717-4562-b3fc-2c963f66afa9"),
                    Prediction = "SCLC",
                    Confidence = 0.89f,
                    PredictionDate = new DateTime(2023, 10, 2)
                }
            };
        }
    }
}