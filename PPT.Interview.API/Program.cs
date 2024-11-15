using PPT.Interview.API.StartupConfig;
using PPT.Interview.Application.SeedWorks;
using PPT.Interview.Application.StratupConfig;
using PPT.Interview.Infrastructure.StartupConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ApplicationSettings appSettings = builder.Configuration.GetSection("ApplicationSettings").Get<ApplicationSettings>()!;
builder.Services.AddSingleton<IApplicationSettings>(_ => appSettings);

builder.Services.ApplicationConfiguration();
builder.Services.InfrastructureConfiguration(builder.Configuration["ConnectionStrings:DbConnection"]!);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCorsAllowAny();
app.UseAuthorization();

app.MapControllers();

app.Run();
