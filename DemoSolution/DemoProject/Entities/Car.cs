using System.ComponentModel.DataAnnotations;

namespace DemoProject.Entities;

public class Car
{
    // data annotations validation

    [RegularExpression("^[a-zA-Z -]+$", ErrorMessage = "Alleen letters en spaties graag")]
    public required string Make { get; set; }

    public required string Model { get; set; }

    public required int Year { get; set; }

    public required string PhotoUrl { get; set; }
}
