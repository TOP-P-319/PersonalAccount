using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public class TeacherGroupSubjectRepo(
    AppDbContext ctx,
    IMapper<TeacherGroupSubjetEntity, TeacherGroupSubjectModel> mapper
) : Repo<TeacherGroupSubjetEntity, TeacherGroupSubjectModel>(ctx, mapper, c => c.TeacherGroupSubjets),
    ITeacherGroupSubjectRepo;