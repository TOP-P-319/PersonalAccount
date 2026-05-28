using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public class TeacherProfileRepo(
    AppDbContext ctx,
    IMapper<TeacherProfileEntity, TeacherProfileModel> mapper
) : ProfileRepo<TeacherProfileEntity, TeacherProfileModel>(ctx, mapper, c => c.TeacherProfiles),
    ITeacherProfileRepo;