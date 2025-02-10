using Domain_Layer.Models;
using Domain_Layer.Modles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Data;

namespace Persistence.Config
{
    public class CTScanConfiguration : IEntityTypeConfiguration<CTScan>
    {
      //  private readonly AppDbContext _context;

        public void Configure(EntityTypeBuilder<CTScan> builder)
            {
                builder.ToTable("CTScans");

                builder.HasKey(c => c.Id);

                builder.Property(c => c.UserId)
                       .IsRequired();

                builder.Property(c => c.ImagePath)
                       .IsRequired()
                       .HasMaxLength(500); 

                builder.Property(c => c.UploadDate)
                       .IsRequired();

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
                    UserId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), // Must exist in Users table
                    ImagePath = "C:\\Users\\abdel\\source\\repos\\Cancer-Detection-master\\Persistence\\Data\\Images\\undraw_Dev_productivity_re_fylf.png" ,
                    UploadDate =  DateTime.Now
                },
                new CTScan
                {
                    Id = Guid.Parse("6fa85f64-5717-4562-b3fc-2c963f66afa9"),
                    UserId = Guid.Parse("4fa85f64-5717-4562-b3fc-2c963f66afa7"), // Must exist in Users table
                    ImagePath = "C:\\Users\\abdel\\source\\repos\\Cancer-Detection-master\\Persistence\\Data\\Images\\download.png",
                    UploadDate = DateTime.Now  
                }
            };
        }
    }
}


