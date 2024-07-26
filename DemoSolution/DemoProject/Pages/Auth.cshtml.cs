using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoProject.Pages;

public class Auth : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    public string Status { get; set; }

    public Auth(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task OnGetRegister()
    {
        var jef = new IdentityUser
        {
            UserName = "Jef",
            Email = "jef@familievanjef.be"
        };
        var result = await _userManager.CreateAsync(jef, "Jef123!");
        if (result.Succeeded)
        {
            Status = "Yes! Geregistreerd!";
        }
        else
        {
            Status = $"Kon niet registreren: {string.Join(", ", result.Errors.Select(x => x.Description))}";
        }
    }
    
    public async Task OnGetLogin()
    {
        var result = await _signInManager.PasswordSignInAsync("Jef", "Jef123!", false, false);
        if (result.Succeeded)
        {
            Status = "Ingelogd!";
        }
        else
        {
            Status = $"Kon niet inloggen: {result.IsLockedOut} | {result.IsNotAllowed} | {result.RequiresTwoFactor}";
        }
    }
    
    public async Task OnGetLogout()
    {
        await _signInManager.SignOutAsync();
        Status = "Uitgelogd!";
    }
    
    public async Task OnGetDoNothing()
    {
        
    }
}