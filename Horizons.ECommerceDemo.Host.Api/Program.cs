using Horizons.ECommerceDemo.Domain.Interfaces;
using Horizons.ECommerceDemo.Infrastructure.Data;
using Horizons.ECommerceDemo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Horizons.ECommerceDemo.Application;
using Horizons.ECommerceDemo.Infrastructure;
using Microsoft.Extensions.Configuration;
using Horizons.ECommerceDemo.Domain.Services;
using Horizons.ECommerceDemo.Infrastructure.DataSeeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddApplicationService();
builder.Services.AddPersistenceServices();
//builder.Services.AddDbContext<AppDbContext>(options =>
//            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{

    options
    .UseSqlServer(builder.Configuration.GetConnectionString("MasterConnection"), opt => opt.UseCompatibilityLevel(110))
   
    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
    .EnableSensitiveDataLogging()
    ;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// Data Seed
using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

var dbContext = services.GetRequiredService<AppDbContext>();

try
{

    if (dbContext != null)
    {

        await dbContext.Database.MigrateAsync();

        await SeedCustomers.SeedCustomersAsync(dbContext);
    }

}
catch (Exception ex)
{
    throw new Exception("Erro While Seeding Data" + ex.Message);
}

app.Run();
