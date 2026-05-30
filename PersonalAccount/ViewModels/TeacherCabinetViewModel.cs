namespace PersonalAccount.ViewModels;

public class TeacherCabinetDisciplineViewModel : ViewModel
{
    public string Name { get; set; } = string.Empty;
}

public class TeacherCabinetGroupViewModel : ViewModel
{
    public string Name { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}

public class TeacherCabinetViewModel : CabinetViewModel
{
    public Dictionary<TeacherCabinetDisciplineViewModel, List<TeacherCabinetGroupViewModel>> GroupsByDisciplines
    {
        get;
        set;
    } = [];
}