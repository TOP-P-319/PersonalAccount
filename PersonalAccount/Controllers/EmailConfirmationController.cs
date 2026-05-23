using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Models;
using PersonalAccount.Services.Smtp;
using PersonalAccount.Services.Tokens;
using PersonalAccount.Utils;

namespace PersonalAccount.Controllers;

public class EmailConfirmationController(ISmtpClientService smtp, IConfirmationTokenService confirmation) : Controller
{
    [HttpGet]
    public IActionResult Index(int studentId, string token) => View(new EmailConfirmationViewModel
    {
        StudentId = studentId,
        Token = token
    });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(EmailConfirmationViewModel model)
    {
        var confirmed = await confirmation.ValidateTokenAsync(model.StudentId, model.Token);
        if (!confirmed) return RedirectToAction("Error", "Home");
        
        return RedirectToAction("Index", "Profile");
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Send()
    {
        var studentId = User.GetId();
        var studentEmail = User.GetEmail();
        if (studentId == null || studentEmail == null) return RedirectToAction("Error", "Home");

        var token = await confirmation.GenerateTokenAsync(studentId.Value);

        var confirmationUrl = Url.Action("Index", "EmailConfirmation", new { studentId, token }, Request.Scheme);

        await smtp.SendEmailAsync(studentEmail, "Подтверждение почты", $"""
                                                                        <body>
                                                                            <a href="{confirmationUrl}">Подтвердить почту</a>
                                                                        </body>
                                                                        """);

        return RedirectToAction("Index", "Profile");
    }
}