namespace PersonalAccount.Models;

public class GroupModel : Model
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Uri? ImageUrl { get; set; }
}