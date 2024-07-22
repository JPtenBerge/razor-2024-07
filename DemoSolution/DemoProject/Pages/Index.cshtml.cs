using DemoProject.Entities;
using DemoProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoProject.Pages;

public class IndexModel : PageModel // bij ieder request wordt deze opnieuw geinstantieerd
{
    public string Bla { get; set; } = "Hey daar!";

    public List<Car> Cars { get; set; } = default!;

    [BindProperty]
    public Car NewCar { get; set; } = default!;

    private ICarRepository _carRepository;

    public IndexModel(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public void OnGet()
    {
        Cars = _carRepository.GetAll().ToList();
    }

    // page handlers

    public IActionResult OnPost() // model binding  reflection
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("dat is NIET valid");
            Cars = _carRepository.GetAll().ToList();
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

        _carRepository.Add(NewCar);
        return RedirectToPage();
    }
}
