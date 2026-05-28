using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalAccount.Data.Entities;

namespace PersonalAccount.Utils;

public static class EntityTypeBuilderEx
{
    public static void BuildEntity<TEntity>(this EntityTypeBuilder<TEntity> entity, string tableName)
        where TEntity : Entity
    {
        entity.ToTable(tableName);
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
    }

    public static void BuildProfileEntity<TProfileEntity>(
        this EntityTypeBuilder<TProfileEntity> entity,
        string tableName,
        Expression<Func<AccountEntity, TProfileEntity?>> profileSelector
    )
        where TProfileEntity : ProfileEntity
    {
        entity.BuildEntity(tableName);
        entity.HasIndex(profile => profile.AccountId).IsUnique();

        entity.Property(profile => profile.AccountId)
            .HasColumnName("account_id")
            .IsRequired();

        entity.Property(profile => profile.FullName)
            .HasColumnName("full_name")
            .HasMaxLength(255)
            .IsRequired();

        entity.Property(profile => profile.PhotoUrl)
            .HasColumnName("photo_url")
            .HasMaxLength(2047);

        entity.HasOne(profile => profile.Account)
            .WithOne(profileSelector)
            .HasForeignKey<TProfileEntity>(profile => profile.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}