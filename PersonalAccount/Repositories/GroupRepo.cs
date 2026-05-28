using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public class GroupRepo(
    AppDbContext ctx,
    IMapper<GroupEntity, GroupModel> mapper
) : Repo<GroupEntity, GroupModel>(ctx, mapper, c => c.Groups),
    IGroupRepo;