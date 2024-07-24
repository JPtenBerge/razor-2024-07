using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoProject.Pages;

public class CarDetailsModel : PageModel
{
    public void OnGet(int id)
    {
        Console.WriteLine("Car details id: " + id);

        Console.WriteLine(Request.Query["hoi"]);
    }
}
