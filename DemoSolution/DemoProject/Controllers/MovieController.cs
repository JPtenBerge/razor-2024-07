using DemoProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers;

[Route("api/movies")]
public class MovieController
{
    public IEnumerable<Movie> Get()
    {
        var fastAndFuriousTokyo = new Movie { Title = "Fast and Furious: Tokyo Drift" };
        var shawshank = new Movie { Title = "The Shawshank Redemption" };
        var bruceAlmighty = new Movie { Title = "Bruce Almighty" };

        var vinny = new Actor { Name = "Vinny Diesel" };
        var morgan = new Actor { Name = "Morgan Freeman" };
        var nat = new Actor { Name = "Nat" };

        fastAndFuriousTokyo.Actors.Add(vinny);
        fastAndFuriousTokyo.Actors.Add(nat);
        shawshank.Actors.Add(morgan);
        bruceAlmighty.Actors.Add(morgan);

        vinny.Movies.Add(fastAndFuriousTokyo);
        nat.Movies.Add(fastAndFuriousTokyo);
        morgan.Movies.Add(shawshank);
        morgan.Movies.Add(bruceAlmighty);

        var movies = new List<Movie> { fastAndFuriousTokyo, shawshank, bruceAlmighty };
        //movies.SelectMany(x => x.Actors).ToList().ForEach(a => a.Movies = null);
        return movies;

    }
}
