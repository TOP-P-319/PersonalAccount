using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Constants;

namespace PersonalAccount.Controllers;

[Authorize(Roles = AccountRoleConstants.Teacher)]
public class TeacherCabinetController : Controller
{
    [HttpGet]
    public IActionResult Index() => View();
}