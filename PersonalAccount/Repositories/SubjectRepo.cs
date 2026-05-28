using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public class SubjectRepo(
    AppDbContext ctx,
    IMapper<SubjectEntity, SubjectModel> mapper
) : Repo<SubjectEntity, SubjectModel>(ctx, mapper, c => c.Subjects),
    ISubjectRepo;