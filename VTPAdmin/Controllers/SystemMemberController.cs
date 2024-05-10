using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VTPAdmin.DAL;
using VTPAdmin.Models;
using VTPAdmin.ViewModels.Users;

[Authorize]
public class SystemMemberController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AppDbContext _dbContext;

    public SystemMemberController(UserManager<AppUser> userManager, AppDbContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
    }


    [HttpGet]
    public IActionResult Index()
    {
        var users = _dbContext.Users.Where(u => u.Email != "superadmin@gmail.com").Select(u => new UserVM
        {
            Email = u.Email,
            Role = "admin"
        }).ToList();

        return View(users);
    }

    [HttpGet("/User/Add")]
    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost("/User/Add")]
    public async Task<IActionResult> CreateUser(CreateUserVM model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "admin");
                return RedirectToAction("Index", "SystemMember");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        return View(model);
    }
}
