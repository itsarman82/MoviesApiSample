using Microsoft.EntityFrameworkCore;
using MoviesApiSample.DAL.Framework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MoviesApiSampleRepository>();
builder.Services.AddScoped<ActorApiSampleRepository>();
builder.Services.AddScoped<DirectorApiSampleRepository>();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<MoviesApiSampleDbContex>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{
    builder.Services.AddDbContext<MoviesApiSampleDbContex>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionConnection")));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
