﻿using DemoShared.Dtos;
using DemoShared.Entities;
using Flurl.Http;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DemoBlazor.Pages;

public partial class Home
{
    public string Name { get; set; } = "JP";

    public List<Car> Cars { get; set; } = new()
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

    //[Inject] public HttpClient Http { get; set; }

    async Task ChangeName()
    {
        Name += " Jef";


        var request = new CarPatchRequestDto(PhotoUrl: "iets anders");
        var dto = await "https://localhost:7054/api/car/14".PatchJsonAsync(request).ReceiveJson<CarPatchResponseDto>();
        Console.WriteLine($"dto: {dto.UpdatedCar.PhotoUrl}");

        //Cars = dto.Cars.Select(x => x.ToEntity()).ToList();

    }

    protected override async Task OnInitializedAsync()
    {
        var request = new CarGetAllRequestDto();

        //var dto = await "https://localhost:7054/api/car".SendJsonAsync(HttpMethod.Get, request).ReceiveJson<CarGetAllResponseDto>();

        var dto = await "https://localhost:7054/api/car".GetJsonAsync<CarGetAllResponseDto>();
        Cars = dto.Cars.Select(x => x.ToEntity()).ToList();

        //var result = await Http.GetFromJsonAsync<IEnumerable<CarDto>>("api/car");

        //var result2 = await Http.PostAsJsonAsync<IEnumerable<string>>("api/car", [ "bla", "hoi" ]);
        //result2.Content.ReadFromJsonAsync<CarDto>();

    }
}
