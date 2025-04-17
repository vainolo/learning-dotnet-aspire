var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

string Summary(int forecast) => forecast switch
{
    <= 0            => "Freezing",
    > 0 and <= 10   => "Cool",
    > 10 and <= 20  => "Mild",
    > 20 and <= 30  => "Warm",
    > 30            => "Scorching"
};

WeatherForecast GenerateForecast(int index)
{
    var temperature = Random.Shared.Next(-20, 55);
    return new
    (
        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        temperature,
        Summary(temperature)
    );
}

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index => GenerateForecast(index)).ToArray();
    return forecast;
});

app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
