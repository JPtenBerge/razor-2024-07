using DemoProject.Entities;
using DemoProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoProject.Pages;

public class IndexModel : PageModel // bij ieder request wordt deze opnieuw geinstantieerd
{
    public string Bla { get; set; } = "Hey daar!";

    public List<Car> Cars { get; set; } = default!;
    public List<CarType> CarTypes { get; set; } = default!;

    [BindProperty]
    public Car NewCar { get; set; } = default!;

    private readonly ICarRepository _carRepository;
    private readonly ICarTypeRepository _carTypeRepository;

    public IndexModel(ICarRepository carRepository, ICarTypeRepository carTypeRepository)
    {
        _carRepository = carRepository;
        _carTypeRepository = carTypeRepository;
    }

    public async Task OnGet()
    {
        Cars = (await _carRepository.GetAllAsync()).ToList();
        CarTypes = (await _carTypeRepository.GetAllAsync()).ToList();
    }

    // page handlers

    public async Task<IActionResult> OnPost() // model binding  reflection
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("dat is NIET valid");
            Cars = (await _carRepository.GetAllAsync()).ToList();
            CarTypes = (await _carTypeRepository.GetAllAsync()).ToList();
            return Page();
        }

        await _carRepository.AddAsync(NewCar);
        return RedirectToPage();
    }
}

