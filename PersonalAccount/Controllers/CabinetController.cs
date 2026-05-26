using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Services.Cabinet;
using PersonalAccount.Services.Tokens;
using PersonalAccount.Types;
using PersonalAccount.Utils;
using PersonalAccount.ViewModels;

namespace PersonalAccount.Controllers;

[Authorize]
public class CabinetController(
    IStudentCabinetService studentCabinetService,
    IAdminCabinetService adminCabinetService,
    IConfirmationTokenService confirmationTokenService)
    : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var accountRole = User.GetRole();
        if (accountRole == null) return Forbid();

        return accountRole.Value switch
        {
            AccountRoles.Student => RedirectToAction("Student"),
            AccountRoles.Admin => RedirectToAction("Admin"),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    [HttpGet]
    [Authorize(Roles = AccountRoleConstants.Admin)]
    public async Task<IActionResult> Admin()
    {
        var accounts = (await adminCabinetService.GetAllStudentAccounts())
            .ToDictionary(account => account.Id);
        var studentProfiles = await adminCabinetService.GetAllStudentProfiles();
        return View(new AdminCabinetViewModel
        {
            Students = studentProfiles.Select(studentProfile => new AdminCabinetStudentViewModel
            {
                FullName = studentProfile.FullName,
                GroupName = studentProfile.GroupName,
                PhotoUrl = studentProfile.PhotoUrl?.ToString(),
                Email = accounts[studentProfile.AccountId].Email
            }).ToList()
        });
    }

    [HttpGet]
    [Authorize(Roles = AccountRoleConstants.Student)]
    public async Task<IActionResult> Student()
    {
        var accountId = User.GetId();
        var accountEmail = User.GetEmail();
        if (accountId == null || accountEmail == null) return Forbid();

        var student = await studentCabinetService.GetByAccountIdAsync(accountId.Value);
        if (student == null) return RedirectToAction("Error", "Home");
        var confirmed = await confirmationTokenService.HasConfirmedTokenAsync(student.AccountId);

        return View(new StudentCabinetViewModel
        {
            FullName = student.FullName,
            Email = accountEmail,
            GroupName = student.GroupName,
            PhotoUrl = student.PhotoUrl?.ToString(),
            IsEmailConfirmed = confirmed
        });
    }
}