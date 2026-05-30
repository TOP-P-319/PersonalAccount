using PersonalAccount.Constants;

namespace PersonalAccount.Models;

public class StudentProfileModel : ProfileModel
{
    public int GroupId { get; set; } = GroupConstants.NoGroup.Id;
    
    public override bool Equals(object? obj) =>
        obj is StudentProfileModel 
        && base.Equals(obj);
}