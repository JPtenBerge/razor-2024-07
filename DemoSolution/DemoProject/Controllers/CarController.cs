using DemoProject.Dtos;
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
    public async Task<CarGetAllResponseDto> GetAll(CarGetAllRequestDto dto)
    {
        var cars = await _carRepository.GetAllAsync();
        return new() { Cars = cars.Select(c => c.ToDto()) }; // mapping car entities => car dtos
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

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<CarPatchResponseDto>> Patch(int id, CarPatchRequestDto dto)
    {
        if (!await _carRepository.ExistsAsync(id))
        {
            return NotFound($"ID {id} was not found");
        }

        var updatedCar = await _carRepository.UpdatePhotoAsync(id, dto.PhotoUrl);
        return new CarPatchResponseDto(UpdatedCar: updatedCar.ToDto());
    }
}
