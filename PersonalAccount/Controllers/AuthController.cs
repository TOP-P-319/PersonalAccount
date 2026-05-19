using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Models;
using PersonalAccount.Services.Auth;

namespace PersonalAccount.Controllers;

public class AuthController(IStudentAuthService auth) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        // TODO: validate model
        
        var student = await auth.ValidateStudentAsync(model.Email, model.Password);
        if (student == null)
        {
            // TODO: return invalid state
        }
        
        return Redirect("/");
    } 
}