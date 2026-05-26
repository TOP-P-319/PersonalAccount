using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Services.Account;
using PersonalAccount.ViewModels;

namespace PersonalAccount.Controllers;

public class AccountController(IAccountService accountService) : Controller
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

        var account = await accountService.ValidateCredentialsAsync(model.Email, model.Password);
        if (account == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        await accountService.SignInAsync(HttpContext, account);
        return Redirect(model.ReturnUrl ?? "/");
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await accountService.SignOutAsync(HttpContext);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
}