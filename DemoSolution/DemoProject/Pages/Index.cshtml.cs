using DemoProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoProject.Pages;

public class IndexModel : PageModel // bij ieder request wordt deze opnieuw geinstantieerd
{
    public string Bla { get; set; } = "Hey daar!";

    public static List<Car> Cars { get; set; } = new()
    {
         new()
         {
             Make = "Audi",
             Model = "A3",
             Year = 2009,
             PhotoUrl = "https://mediaservice.audi.com/media/cdb/data/05225e7e-f258-4480-a507-82b685de3e4c.jpg"
         },
         new()
         {
             Make = "Mercedes",
             Model = "C-klasse",
             Year = 1997,
             PhotoUrl = "https://www.autoscout24.nl/cms-content-assets/4g3kfFNhcexmrTog3lFvri-3705d0e65f39b5fe8e956103fc7186f5-mercedes-benz-c-klasse-front-1100.jpeg"
         },
         new()
         {
             Make = "BMW",
             Model = "i8",
             Year = 2012,
             PhotoUrl = "https://www.autoscout24.nl/cms-content-assets/1qhZ7ZHX4kd72nm3gLfLK1-121bb7fb53d3c56af256950f1ff01dda-BMW-i8_Roadster-2019-1280-04-1100.jpg"
         }
    };

    public Car NewCar { get; set; } = default!;

    public void OnGet()
    {

    }

    // page handlers

    public IActionResult OnPost() // model binding  reflection
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("dat is NIET valid");
            return Page();
        }

        // action results:
        // - OkResult
        // - BadRequestResult
        // - NotFoundResult
        // - CreatedResult
        // - ContentResult
        // - JsonResult
        // - FileResult
        // - allerlei redirect
        // - PageResult
        // - RedirectToPageResult

        Cars.Add(NewCar);
        return RedirectToPage();
    }
}
