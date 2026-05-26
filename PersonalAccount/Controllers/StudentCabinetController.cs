using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Services.Cabinet;
using PersonalAccount.Services.Tokens;
using PersonalAccount.Types;
using PersonalAccount.Utils;
using PersonalAccount.ViewModels;

namespace PersonalAccount.Controllers;

[Authorize(Roles = AccountRoleConstants.Student)]
public class StudentCabinetController(
    IStudentCabinetService cabinetService,
    IConfirmationTokenService confirmationTokenService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var accountId = User.GetId();
        var accountEmail = User.GetEmail();
        if (accountId == null || accountEmail == null) return Forbid();

        var student = await cabinetService.GetByAccountIdAsync(accountId.Value);
        if (student == null) return RedirectToAction("Error", "Home");
        var confirmed = await confirmationTokenService.HasConfirmedTokenAsync(student.AccountId);
        var group = student.GroupId == null ? null : await cabinetService.GetGroupByIdAsync(student.GroupId.Value);

        return View(new StudentCabinetViewModel
        {
            FullName = student.FullName,
            Email = accountEmail,
            GroupName = group?.Name ?? "Без группы",
            PhotoUrl = student.PhotoUrl?.ToString(),
            IsEmailConfirmed = confirmed
        });
    }
}