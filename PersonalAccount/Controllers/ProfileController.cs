using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Services.Cabinet;
using PersonalAccount.Services.Tokens;
using PersonalAccount.Utils;
using PersonalAccount.ViewModels;

namespace PersonalAccount.Controllers;

[Authorize]
public class ProfileController(IStudentCabinetService students, IConfirmationTokenService confirmations) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var accountId = User.GetId();
        var accountEmail =  User.GetEmail();
        if (accountId == null || accountEmail == null) return Forbid();
        
        var student = await students.GetByAccountIdAsync(accountId.Value);
        if (student == null) return RedirectToAction("Error", "Home");
        var confirmed = await confirmations.HasConfirmedTokenAsync(student.AccountId);
        
        return View(new StudentProfileViewModel
        {
            FullName = student.FullName,
            Email = accountEmail,
            GroupName = student.GroupName,
            PhotoUrl = student.PhotoUrl?.ToString(),
            IsEmailConfirmed = confirmed
        });
    }
}