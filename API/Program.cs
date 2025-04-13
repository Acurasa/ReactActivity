using Microsoft.EntityFrameworkCore;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader()
    .WithOrigins("http://localhost:3000", "https://localhost:3000"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
try
{
    var dbContext = serviceProvider.GetService<AppDbContext>();
    var logger = serviceProvider.GetService<ILogger<Program>>();
    
    logger.LogInformation("Applying migrations..."); 
    await dbContext.Database.MigrateAsync();
    
    logger.LogInformation("Seeding data...");
    await DbInitializer.SeedData(dbContext);
    
    logger.LogInformation("Data seeded successfully.");
}
catch (Exception e)
{
    var logger = serviceProvider.GetService<ILogger<Program>>();
    logger.LogError(e, "Error while seeding data occurred");
    throw;
}
app.Run();