using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var planets = new[]
{
    new { Name = "Mars", Description = "The Red Planet", FunFact = "Mars has the largest dust storms in the solar system." },
    new { Name = "Jupiter", Description = "The Gas Giant", FunFact = "Jupiter has a storm called the Great Red Spot that has been raging for over 400 years." },
    new { Name = "Saturn", Description = "The Ringed Planet", FunFact = "Saturn's rings are made mostly of ice and rock." }
};

var astronauts = new[]
{
    new { Name = "Neil Armstrong", FirstWords = "That's one small step for man, one giant leap for mankind." },
    new { Name = "Yuri Gagarin", FirstWords = "I see Earth! It is so beautiful." },
    new { Name = "Sally Ride", FirstWords = "The thing I'll remember most about the flight is that it was fun." }
};

app.MapGet("/", () => "Welcome to the Space Adventure API! Try /planets, /astronauts, or /mission");

app.MapGet("/planets", () => 
{
    var random = new Random();
    return planets[random.Next(planets.Length)];
});

app.MapGet("/astronauts", () => 
{
    var random = new Random();
    return astronauts[random.Next(astronauts.Length)];
});

app.MapGet("/mission", () => 
{
    var random = new Random();
    var planet = planets[random.Next(planets.Length)];
    var astronaut = astronauts[random.Next(astronauts.Length)];
    return $"New mission: {astronaut.Name} is going to {planet.Name}! {planet.FunFact}";
});

app.Run();