using Microsoft.EntityFrameworkCore;
using PersonalAccount.Data.Entities;

namespace PersonalAccount.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<StudentEntity> Students => Set<StudentEntity>();
    public DbSet<ConfirmationTokenEntity> ConfirmationTokens => Set<ConfirmationTokenEntity>();

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

        modelBuilder.Entity<ConfirmationTokenEntity>(entity =>
        {
            entity.ToTable("confirmation_tokens");
            entity.HasKey(token => token.Id);

            entity.Property(token => token.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entity.Property(token => token.StudentId)
                .HasColumnName("student_id")
                .IsRequired();

            entity.Property(token => token.TokenHash)
                .HasColumnName("token_hash")
                .IsRequired();

            entity.Property(token => token.ExpiresAt)
                .HasColumnName("expires_at")
                .IsRequired();

            entity.Property(token => token.ConfirmedAt)
                .HasColumnName("confirmed_at");
            
            entity.HasOne(token => token.Student)
                .WithMany(student => student.ConfirmationTokens)
                .HasForeignKey(token => token.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}