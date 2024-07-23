using DemoProject.Entities;

namespace DemoProject.Repositories
{
    public interface ICarTypeRepository
    {
        Task<IEnumerable<CarType>> GetAllAsync();
    }
}