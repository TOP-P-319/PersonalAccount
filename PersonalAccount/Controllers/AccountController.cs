using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Services.Account;
using PersonalAccount.Utils;

namespace PersonalAccount.Controllers;

[Authorize]
public class AccountController(IStudentService students) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var studentId = User.GetId();
        if (studentId == null) return RedirectToAction("Error", "Home");
        var student = await students.GetByIdAsync(studentId.Value);
        
        return View(student);
    }
}