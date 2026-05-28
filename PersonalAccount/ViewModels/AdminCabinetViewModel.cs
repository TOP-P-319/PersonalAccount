namespace PersonalAccount.ViewModels;

public class AdminCabinetStudentViewModel : ViewModel
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string GroupName { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; }
}

public class AdminCabinetViewModel : ViewModel
{
    public List<AdminCabinetStudentViewModel> Students { get; set; } = [];
}