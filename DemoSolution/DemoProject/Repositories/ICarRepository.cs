using DemoProject.Entities;

namespace DemoProject.Repositories
{
    public interface ICarRepository
    {
        Task<Car> AddAsync(Car newCar);
        Task<IEnumerable<Car>> GetAllAsync();
    }
}