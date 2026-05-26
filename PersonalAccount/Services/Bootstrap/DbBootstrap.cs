using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models.Student;
using PersonalAccount.Utils;

namespace PersonalAccount.Services.Bootstrap;

public class DbBootstrap(
    AppDbContext ctx,
    IMapper<StudentProfileEntity, StudentAuthModel> mapper,
    IPasswordHasher<StudentAuthModel> hasher)
{
    public async Task SeedAsync()
    {
        var hasStudents = await ctx.StudentProfiles.AnyAsync();
        if (hasStudents) return;

        var model = new StudentAuthModel
        {
            FullName = "John Doe",
            GroupName = "P-319",
            Email = "shamraev.alexandr@gmail.com",
            PhotoUrl =
                "https://img.magnific.com/free-photo/view-beautiful-persian-domestic-cat_23-2151773821.jpg?semt=ais_hybrid&w=740&q=80"
                    .ToUri()
        };

        var entity = mapper.ToEntity(model);
        entity.PasswordHash = hasher.HashPassword(model, "example");
        
        await ctx.StudentProfiles.AddAsync(entity);
        await ctx.SaveChangesAsync();
    }
}