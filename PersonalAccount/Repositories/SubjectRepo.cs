using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public class DisciplineRepo(
    AppDbContext ctx,
    IMapper<DisciplineEntity, DisciplineModel> mapper
) : Repo<DisciplineEntity, DisciplineModel>(ctx, mapper, c => c.Disciplines),
    IDisciplineRepo;