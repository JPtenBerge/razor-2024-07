namespace DemoProject.Dtos;

public record CarPatchRequestDto(string PhotoUrl);

public record CarPatchResponseDto(CarDto UpdatedCar);
