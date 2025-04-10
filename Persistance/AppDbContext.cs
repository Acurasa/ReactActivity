using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public class AppDbContext(DbContextOptions opt) : DbContext(opt)
{
 public required DbSet<Activity> Activities { get; set; }
 
}