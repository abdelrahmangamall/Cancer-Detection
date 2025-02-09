using Domain_Layer.Modles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            // Configure the primary key
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.PasswordHash)
                   .IsRequired();

            builder.Property(u => u.PasswordSalt)
                   .IsRequired(); 

            builder.HasIndex(u => u.Email)
                   .IsUnique();
            builder.HasData(LoadUsers());
        }

        private static List<User> LoadUsers()
        {
            return new List<User>
            {

              new User
              {
                  Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), // Must exist in Users table
                  Email = "admin@example.com",
                  PasswordHash = new byte[] { 0x01, 0x02, 0x03 },
                  PasswordSalt = new byte[] { 0x04, 0x05, 0x06 }
              },
              new User
              {
                  Id = Guid.Parse("4fa85f64-5717-4562-b3fc-2c963f66afa7"), // Must exist in Users table
                  Email = "user@example.com",
                  PasswordHash = new byte[] { 0x07, 0x08, 0x09 },
                  PasswordSalt = new byte[] { 0x0A, 0x0B, 0x0C }
              }
            };
        }
    }
    }


