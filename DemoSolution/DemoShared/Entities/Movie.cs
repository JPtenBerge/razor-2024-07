using System.Text.Json.Serialization;

namespace DemoShared.Entities;

public class Movie
{
    public string Title { get; set; }

    public List<Actor> Actors { get; set; } = new();
}
