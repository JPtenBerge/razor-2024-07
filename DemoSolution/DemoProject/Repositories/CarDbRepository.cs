using DemoProject.DataAccess;
using DemoProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repositories;

public class CarDbRepository : ICarRepository
{
    private DemoContext _context;

    public CarDbRepository(DemoContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        return await _context.Cars.Include(x => x.Type).ToListAsync();
    }

    public async Task<Car> AddAsync(Car newCar)
    {
        _context.Cars.Add(newCar);

        await _context.SaveChangesAsync(); // zet Id
        return newCar; // updated entity
    }
}
