using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public class StudentProfileRepo(
    AppDbContext ctx,
    IMapper<StudentProfileEntity, StudentProfileModel> mapper
) : ProfileRepo<StudentProfileEntity, StudentProfileModel>(ctx, mapper, c => c.StudentProfiles),
    IStudentProfileRepo;