using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Persistence.Config
{
    public class CTScanConfiguration : IEntityTypeConfiguration<CTScan>
    {
        public void Configure(EntityTypeBuilder<CTScan> builder)
        {
            builder.ToTable("CTScans");

            builder.HasKey(c => c.Id);


            builder.Property(c => c.FileName)
                   .IsRequired()
                   .HasMaxLength(255); 

            builder.Property(c => c.FilePath)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(c => c.UploadDate)
                   .IsRequired();

           

            builder.HasData(LoadCTScans());
        }

        private static List<CTScan> LoadCTScans()
        {
            return new List<CTScan>
            {
                new CTScan
                {
                    Id = Guid.Parse("5fa85f64-5717-4562-b3fc-2c963f66afa8"),
                    FileName = "undraw_Dev_productivity_re_fylf.png",
                    FilePath = "C:\\Users\\abdel\\source\\repos\\Cancer-Detection-master\\Persistence\\Data\\Images\\undraw_Dev_productivity_re_fylf.png",
                    UploadDate = DateTime.Now,
                },
                new CTScan
                {
                    Id = Guid.Parse("6fa85f64-5717-4562-b3fc-2c963f66afa9"),
                    FileName = "download.png",
                    FilePath = "C:\\Users\\abdel\\source\\repos\\Cancer-Detection-master\\Persistence\\Data\\Images\\download.png",
                    UploadDate = DateTime.Now,
                }
            };
        }
    }
}