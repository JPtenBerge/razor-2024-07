namespace DemoProject.Entities;

public class CarType
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public required IEnumerable<Car> Cars { get; set; }
}
