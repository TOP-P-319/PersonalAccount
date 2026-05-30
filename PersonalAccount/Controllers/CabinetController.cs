using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Types;
using PersonalAccount.Utils;

namespace PersonalAccount.Controllers;

[Authorize]
public class CabinetController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var accountRole = User.GetRole();
        if (accountRole == null) return Forbid();

        return accountRole.Value switch
        {
            AccountRoles.Student => RedirectToAction("Index", "StudentCabinet"),
            AccountRoles.Teacher => RedirectToAction("Index", "TeacherCabinet"),
            AccountRoles.Admin => RedirectToAction("Index", "AdminPanel"),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}