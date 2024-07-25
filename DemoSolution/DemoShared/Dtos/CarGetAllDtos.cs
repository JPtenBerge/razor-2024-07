using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Numerics;
using DemoShared.Entities;

namespace DemoShared.Dtos;

public record CarDto(int Id, string Make, string Model, int Year, string PhotoUrl, string Type);

public record CarGetAllRequestDto { }

public record CarGetAllResponseDto
{
    public required IEnumerable<CarDto> Cars { get; set; }

    //public int TotalNrOfCars { get; set; }

    //public int CurrentPage { get; set; }
}

public static class CarGetAllExtensions
{
    public static CarDto ToDto(this Car car)
    {
        return new(
            Id: car.Id,
            Make: car.Make,
            Model: car.Model,
            Year: car.Year,
            PhotoUrl: car.PhotoUrl,
            Type: car.Type.Name
        );
    }
}