using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Constants;
using PersonalAccount.Services.Cabinet;
using PersonalAccount.Services.Smtp;
using PersonalAccount.ViewModels;

namespace PersonalAccount.Controllers;

[Authorize(Roles = AccountRoleConstants.Admin)]
public class AdminPanelController(
    IAdminPanelService panelService,
    ISmtpClientService smtpClientService
) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var accounts = (await panelService.GetAllStudentAccountsAsync())
            .ToDictionary(account => account.Id);
        var groups = (await panelService.GetAllGroupsAsync())
            .ToDictionary(group => group.Id);
        var studentProfiles = await panelService.GetAllStudentProfilesAsync();

        return View(new AdminPanelViewModel
        {
            Students = studentProfiles.Select(studentProfile => new AdminPanelStudentViewModel
            {
                FullName = studentProfile.FullName,
                GroupName = groups[studentProfile.GroupId].Name,
                PhotoUrl = studentProfile.PhotoUrl?.ToString(),
                Email = accounts[studentProfile.AccountId].Email
            }).ToList()
        });
    }

    [HttpGet]
    public IActionResult RegisterStudent() => View(new RegisterStudentViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterStudent(RegisterStudentViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var isUnique = await panelService.CheckEmailUniqueAsync(model.Email);
        if (!isUnique)
        {
            ModelState.AddModelError(string.Empty, $"Email {model.Email} is already taken.");
            return View(model);
        }

        var password = await panelService.RegisterStudentAccountWithGeneratedPasswordAsync(model.Email);
        await panelService.RegisterStudentProfileForEmailAsync(model.Email, model.FullName);

        await smtpClientService.SendEmailAsync(model.ContactEmail, "Данные для входа в систему", $"""
             <body>
                 <p>{model.Email}</p>
                 <p>{password}</p>
             </body>
             """);

        return RedirectToAction("Index");
    }
}