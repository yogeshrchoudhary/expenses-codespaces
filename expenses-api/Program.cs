using expenses_api.Endpoints;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddEnvironmentVariables();

builder.Services.AddCors(options =>
{
    // NOTE: To allow requests from the frontend application running on GitHub Codespaces, 
    // this HTTP API needs to be served on a public port when running in Codespaces.
    options.AddPolicy("AllowFrontend", policy =>
    {
        builder.Configuration.GetSection("AllowedOrigins").Get<string[]>()?.ToList().ForEach(origin =>
        {
            policy.WithOrigins(origin)
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
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

new ExpenesEndpoints().Map(app);
new WeatherForecastEndpoints().Map(app);

app.Run();

