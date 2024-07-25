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

    public async Task<Car?> GetAsync(int id)
    {
        return await _context.Cars.Include(x => x.Type).SingleOrDefaultAsync(x => x.Id == id);
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

    public async Task<Car> UpdatePhotoAsync(int id, string photoUrl)
    {
        //await _context.Cars
        //    .Where(x => x.Id == id)
        //    .ExecuteUpdateAsync(setters => setters.SetProperty(x => x.PhotoUrl, photoUrl));

        var entity = await _context.Cars.Include(x => x.Type).SingleAsync(x => x.Id == id);
        entity.PhotoUrl = photoUrl;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Cars.AnyAsync(x => x.Id == id);
    }
}
