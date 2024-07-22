using DemoProject.Entities;

namespace DemoProject.Repositories
{
    public interface ICarRepository
    {
        Car Add(Car newCar);
        IEnumerable<Car> GetAll();
    }
}