using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Services.Profile;
using PersonalAccount.Utils;

namespace PersonalAccount.Controllers;

[Authorize]
public class ProfileController(IStudentProfileService students) : Controller
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