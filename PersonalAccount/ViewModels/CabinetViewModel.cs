using Microsoft.AspNetCore.Html;

namespace PersonalAccount.ViewModels;

public class CabinetViewModel : ViewModel
{
    public string? PhotoUrl { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsEmailConfirmed { get; set; }

    public string Title { get; set; } = string.Empty;
    public IHtmlContent AdditionalInfoBody { get; set; } = HtmlString.Empty;
}