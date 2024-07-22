using DemoProject.Entities;

namespace DemoProject.Repositories;


// Create-Read-Update-Delete
// persistentielogica

public class CarInMemoryRepository : ICarRepository
{
    private List<Car> _cars { get; set; } = new()
    {
         new()
         {
             Id = 4,
             Make = "Audi uit repo",
             Model = "A3",
             Year = 2009,
             PhotoUrl = "https://mediaservice.audi.com/media/cdb/data/05225e7e-f258-4480-a507-82b685de3e4c.jpg"
         },
         new()
         {
             Id = 8,
             Make = "Mercedes",
             Model = "C-klasse",
             Year = 1997,
             PhotoUrl = "https://www.autoscout24.nl/cms-content-assets/4g3kfFNhcexmrTog3lFvri-3705d0e65f39b5fe8e956103fc7186f5-mercedes-benz-c-klasse-front-1100.jpeg"
         },
         new()
         {
             Id = 15,
             Make = "BMW",
             Model = "i8",
             Year = 2012,
             PhotoUrl = "https://www.autoscout24.nl/cms-content-assets/1qhZ7ZHX4kd72nm3gLfLK1-121bb7fb53d3c56af256950f1ff01dda-BMW-i8_Roadster-2019-1280-04-1100.jpg"
         }
    };

    public Task<IEnumerable<Car>> GetAllAsync()
    {
        return Task.FromResult(_cars.AsEnumerable());
    }

    public Task<Car> AddAsync(Car newCar)
    {
        newCar.Id = _cars != null && _cars.Any() ? _cars.Max(x => x.Id) + 1 : 1;
        _cars.Add(newCar);
        return Task.FromResult(newCar);
    }
}
