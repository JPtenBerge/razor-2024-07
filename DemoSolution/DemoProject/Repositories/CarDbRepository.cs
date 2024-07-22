using DemoProject.DataAccess;
using DemoProject.Entities;

namespace DemoProject.Repositories;

public class CarDbRepository : ICarRepository
{
    private DemoContext _context;

    public CarDbRepository(DemoContext context)
    {
        _context = context;
    }
    public IEnumerable<Car> GetAll()
    {
        return _context.Cars.ToList();
    }

    public Car Add(Car newCar)
    {
        _context.Cars.Add(newCar);
        _context.SaveChanges(); // zet Id
        return newCar; // updated entity
    }
}
