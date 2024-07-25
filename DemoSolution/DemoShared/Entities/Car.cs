using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoShared.Entities;

public class Car
{
    // data annotations validation

    public int Id { get; set; }

    [RegularExpression("^[a-zA-Z -]+$", ErrorMessage = "Alleen letters en spaties graag")]
    public required string Make { get; set; }

    public required string Model { get; set; }

    public required int Year { get; set; }

    public required string PhotoUrl { get; set; }

    public CarType Type { get; set; } // gebruik ik voor display purposes

    [DisplayName("Type hier")]
    public int TypeId { get; set; } // gebruik ik voor het toevoegen/wijzigen
}
