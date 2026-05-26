using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Models;
using PersonalAccount.Services.Account;
using PersonalAccount.ViewModels;

namespace PersonalAccount.Controllers;

public class AccountController(IAccountService auth) : Controller
{
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        return View(new LoginViewModel
        {
            ReturnUrl = returnUrl
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var account = await auth.ValidateCredentialsAsync(model.Email, model.Password);
        if (account == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        await auth.SignInAsync(HttpContext, account);
        return Redirect(model.ReturnUrl ?? "/");
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await auth.SignOutAsync(HttpContext);
        return RedirectToAction("Index", "Home");
    }
}