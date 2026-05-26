using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Models;
using PersonalAccount.Services.Smtp;
using PersonalAccount.Services.Tokens;
using PersonalAccount.Utils;
using PersonalAccount.ViewModels;

namespace PersonalAccount.Controllers;

public class EmailConfirmationController(ISmtpClientService smtp, IConfirmationTokenService confirmation) : Controller
{
    [HttpGet]
    public IActionResult Index(int accountId, string token) => View(new EmailConfirmationViewModel
    {
        AccountId = accountId,
        Token = token
    });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(EmailConfirmationViewModel model)
    {
        var confirmed = await confirmation.ValidateTokenAsync(model.AccountId, model.Token);
        if (!confirmed) return RedirectToAction("Error", "Home");
        
        return RedirectToAction("Index", "Cabinet");
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Send()
    {
        var accountId = User.GetId();
        var accountEmail = User.GetEmail();
        if (accountId == null || accountEmail == null) return RedirectToAction("Error", "Home");

        var token = await confirmation.GenerateTokenAsync(accountId.Value);

        var confirmationUrl = Url.Action("Index", "EmailConfirmation", new { accountId, token }, Request.Scheme);

        await smtp.SendEmailAsync(accountEmail, "Подтверждение почты", $"""
                                                                        <body>
                                                                            <a href="{confirmationUrl}">Подтвердить почту</a>
                                                                        </body>
                                                                        """);

        return RedirectToAction("Index", "Cabinet");
    }
}