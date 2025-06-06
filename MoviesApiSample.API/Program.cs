using Microsoft.EntityFrameworkCore;
using MoviesApiSample.DAL.Framework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MoviesApiSampleDbContex>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMoviesApiSampleRepository, MoviesApiSampleRepository>();
builder.Services.AddScoped<IActorApiSampleRepository, ActorApiSampleRepository>();
builder.Services.AddScoped<IDirectorApiSampleRepository, DirectorApiSampleRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
