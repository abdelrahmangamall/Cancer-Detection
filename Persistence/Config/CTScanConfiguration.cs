using Domain_Layer.Models;
using Domain_Layer.Modles;
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

            builder.Property(c => c.UserId)
                   .IsRequired();

            builder.Property(c => c.FileName)
                   .IsRequired()
                   .HasMaxLength(255); 

            builder.Property(c => c.StoredFileName)
                   .IsRequired()
                   .HasMaxLength(255); 

            builder.Property(c => c.FileSize)
                   .IsRequired();

            builder.Property(c => c.ContentType)
                   .IsRequired()
                   .HasMaxLength(100); 

            builder.Property(c => c.FilePath)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(c => c.UploadDate)
                   .IsRequired();

            builder.Property(c => c.Width)
                   .IsRequired(false); 

            builder.Property(c => c.Height)
                   .IsRequired(false); 

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(LoadCTScans());
        }

        private static List<CTScan> LoadCTScans()
        {
            return new List<CTScan>
            {
                new CTScan
                {
                    Id = Guid.Parse("5fa85f64-5717-4562-b3fc-2c963f66afa8"),
                    UserId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), 
                    FileName = "undraw_Dev_productivity_re_fylf.png",
                    StoredFileName = "unique_filename_1.png",
                    FileSize = 1024, 
                    ContentType = "image/png",
                    FilePath = "C:\\Users\\abdel\\source\\repos\\Cancer-Detection-master\\Persistence\\Data\\Images\\undraw_Dev_productivity_re_fylf.png",
                    UploadDate = DateTime.Now,
                    Width = 800, 
                    Height = 600 
                },
                new CTScan
                {
                    Id = Guid.Parse("6fa85f64-5717-4562-b3fc-2c963f66afa9"),
                    UserId = Guid.Parse("4fa85f64-5717-4562-b3fc-2c963f66afa7"), 
                    FileName = "download.png",
                    StoredFileName = "unique_filename_2.png",
                    FileSize = 2048, 
                    ContentType = "image/png",
                    FilePath = "C:\\Users\\abdel\\source\\repos\\Cancer-Detection-master\\Persistence\\Data\\Images\\download.png",
                    UploadDate = DateTime.Now,
                    Width = 1024,
                    Height = 768 
                }
            };
        }
    }
}