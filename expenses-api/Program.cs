using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    // NOTE: To allow requests from the frontend application running on GitHub Codespaces, 
    // this HTTP API needs to be served on a public port when running in Codespaces.
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://psychic-fortnight-rr5ppq554pwhx7jx-4200.app.github.dev") 
              .AllowAnyMethod()
              .AllowAnyHeader();        
    });
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Generate the Swagger document
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Expenses api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Enable swagger - this does not display the Swagger UI
app.UseSwagger();
// Enable Swagger UI, this will allow you to browse the /swagger endpoint for an interactive API document
app.UseSwaggerUI(options => options.SwaggerEndpoint("v1/swagger.json", "My Expenses API"));

app.UseCors("AllowFrontend");

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/expenses", () =>
{
    return new[] { "Expense1", "Expense2", "Expense3" };
})
.WithName("GetExpenses");


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
