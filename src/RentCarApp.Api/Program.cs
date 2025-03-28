using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentCarApp.Domain.Entities;
using RentCarApp.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StrDataContext") ?? throw new InvalidOperationException("Connection string 'DataContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var MY_ALLOW_ORIGINS = "AllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MY_ALLOW_ORIGINS,
        policy =>
        {
            policy.WithOrigins("https://localhost:7007")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});
builder.Services.AddTransient<StatusRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(MY_ALLOW_ORIGINS);
app.Run();
