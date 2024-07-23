using DemoProject.DataAccess;
using DemoProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repositories;

public class CarTypeDbRepository : ICarTypeRepository
{
    private DemoContext _context;

    public CarTypeDbRepository(DemoContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<CarType>> GetAllAsync()
    {
        return await _context.CarTypes.ToListAsync();
    }

}
