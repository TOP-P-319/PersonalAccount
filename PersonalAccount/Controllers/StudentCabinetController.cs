using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Constants;
using PersonalAccount.Services.Cabinet;
using PersonalAccount.Services.Tokens;
using PersonalAccount.Types;
using PersonalAccount.Utils;
using PersonalAccount.ViewModels;

namespace PersonalAccount.Controllers;

[Authorize(Roles = AccountRoleConstants.Student)]
public class StudentCabinetController(
    IStudentCabinetService cabinetService,
    IConfirmationTokenService confirmationTokenService
    ) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var accountId = User.GetId();
        var accountEmail = User.GetEmail();
        if (accountId == null || accountEmail == null) return Forbid();

        var studentProfile = await cabinetService.GetProfileAsync(accountId.Value);
        if (studentProfile == null) return RedirectToAction("Error", "Home");
        var confirmed = await confirmationTokenService.HasConfirmedTokenAsync(studentProfile.AccountId);
        var group = await cabinetService.GetGroupAsync(studentProfile.GroupId);
        if (group == null) return RedirectToAction("Error", "Home");

        return View(new StudentCabinetViewModel
        {
            FullName = studentProfile.FullName,
            Email = accountEmail,
            GroupName = group.Name,
            PhotoUrl = studentProfile.PhotoUrl?.ToString(),
            IsEmailConfirmed = confirmed
        });
    }
}