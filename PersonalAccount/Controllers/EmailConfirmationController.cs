using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Models;
using PersonalAccount.Services.Smtp;
using PersonalAccount.Utils;

namespace PersonalAccount.Controllers;

public class EmailConfirmationController(ISmtpClientService smtp) : Controller
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
        Console.WriteLine($"{model.StudentId}:  {model.Token}");
        // TODO: сверить токен с токеном в базе и записать, что почта подтверждена
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

        // TODO: реализовать генерацию токена и его сохранение в БД

        var confirmationUrl = Url.Action("Index", "EmailConfirmation", new { studentId, token="TEST" }, Request.Scheme);

        await smtp.SendEmailAsync(studentEmail, "Подтверждение почты", $"""
                                                                        <body>
                                                                            <a href="{confirmationUrl}">Подтвердить почту</a>
                                                                        </body>
                                                                        """);

        return RedirectToAction("Index", "Profile");
    }
}