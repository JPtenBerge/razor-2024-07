using DemoProject.Entities;

namespace DemoProject.Repositories
{
    public interface ICarRepository
    {
        Task<Car> AddAsync(Car newCar);
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car?> GetAsync(int id);

        Task<Car> UpdatePhotoAsync(int id, string photoUrl);
        Task<bool> ExistsAsync(int id);

    }
}