using RestaurantReservation.Db;
using RestaurantReservation.API.Interfaces;
using RestaurantReservation.API.Services;
using RestaurantReservation.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().SetBasePath(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\")))
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

builder.Services.AddDbContext<RestaurantReservationDbContext>(options => options.UseSqlServer(config.GetConnectionString("RestaurantReservationCore")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
