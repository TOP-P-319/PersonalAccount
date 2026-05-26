namespace PersonalAccount.Data.Entities;

public class GroupEntity
{
    public int Id { get; set; }
    public List<StudentProfileEntity> StudentProfiles { get; set; } = [];

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}