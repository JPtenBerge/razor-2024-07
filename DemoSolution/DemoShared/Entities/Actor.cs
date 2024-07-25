namespace DemoShared.Entities;

public class Actor
{
    public string Name { get; set; }

    public List<Movie> Movies { get; set; } = new();
}
