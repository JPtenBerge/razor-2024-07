﻿using System.Text.Json.Serialization;

namespace DemoShared.Entities;

public class CarType
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    [JsonIgnore]
    public IEnumerable<Car> Cars { get; set; }
}