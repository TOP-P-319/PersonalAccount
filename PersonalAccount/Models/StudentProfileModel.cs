using PersonalAccount.Constants;

namespace PersonalAccount.Models;

public class StudentProfileModel : ProfileModel
{
    public int GroupId { get; set; } = GroupConstants.NoGroup.Id;
}