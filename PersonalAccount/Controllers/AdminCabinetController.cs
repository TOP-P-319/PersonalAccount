using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Constants;
using PersonalAccount.Services.Cabinet;
using PersonalAccount.Types;
using PersonalAccount.ViewModels;

namespace PersonalAccount.Controllers;

[Authorize(Roles = AccountRoleConstants.Admin)]
public class AdminCabinetController(IAdminCabinetService cabinetService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var accounts = (await cabinetService.GetAllStudentAccountsAsync())
            .ToDictionary(account => account.Id);
        var groups = (await cabinetService.GetAllGroupsAsync())
            .ToDictionary(group => group.Id);
        var studentProfiles = await cabinetService.GetAllStudentProfilesAsync();

        return View(new AdminCabinetViewModel
        {
            Students = studentProfiles.Select(studentProfile => new AdminCabinetStudentViewModel
            {
                FullName = studentProfile.FullName,
                GroupName = groups[studentProfile.GroupId].Name,
                PhotoUrl = studentProfile.PhotoUrl?.ToString(),
                Email = accounts[studentProfile.AccountId].Email
            }).ToList()
        });
    }
}