using DemoProject.Entities;
using DemoProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers;

[Route("api/[controller]")]
[ApiController] // ModelState.IsValid  [FromBody]
public class CarController : ControllerBase
{
    private readonly ICarRepository _carRepository;

    public CarController(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Car>> GetAll()
    {
        return await _carRepository.GetAllAsync();
    }

    [HttpGet("{id:min(1)}")]
    public async Task<ActionResult<Car>> Get(int id)
    {


        var car = await _carRepository.GetAsync(id);
        return car != null ? car : NotFound($"ID {id} does not exist");
    }

    [HttpPost]
    public async Task<ActionResult<Car>> Post(Car newCar)
    {
        await _carRepository.AddAsync(newCar);
        return CreatedAtAction(nameof(Get), new { id = newCar.Id }, newCar);
    }
}
