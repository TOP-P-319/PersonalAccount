using Microsoft.EntityFrameworkCore;
using PersonalAccount.Data.Entities;

namespace PersonalAccount.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<StudentEntity> Students => Set<StudentEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<StudentEntity>(entity =>
        {
            entity.ToTable("students");
            entity.HasKey(student => student.Id);
            entity.HasIndex(student => student.Email).IsUnique();

            entity.Property(student => student.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entity.Property(student => student.FullName)
                .HasColumnName("full_name")
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(student => student.GroupName)
                .HasColumnName("group_name")
                .HasMaxLength(255)
                .IsRequired();
            
            entity.Property(student => student.Email)
                .HasColumnName("email")
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(student => student.PhotoUrl)
                .HasColumnName("photo_url")
                .HasMaxLength(2047);

            entity.Property(student => student.PasswordHash)
                .HasColumnName("password_hash")
                .IsRequired();
        });
    }
}