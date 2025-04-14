using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public class AppDbContext(DbContextOptions opt) : DbContext(opt)
{
 public required DbSet<Activity?> Activities { get; set; }
 
 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
  modelBuilder.Entity<Activity>()
   .ToTable("Activities");  
    
  base.OnModelCreating(modelBuilder);
 }

 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
  optionsBuilder.EnableSensitiveDataLogging();
   
  base.OnConfiguring(optionsBuilder);
 }
}