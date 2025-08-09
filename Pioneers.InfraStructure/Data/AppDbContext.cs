using Microsoft.EntityFrameworkCore;
using Pioneers.Core.Models;

namespace Pioneers.InfraStructure.Data;
public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    { }
    public DbSet<Employee> employees { get; set; }
    public DbSet<CustomProperty> customProperty { get; set; }
    public DbSet<DropdownOption> DropdownOptions { get; set; }

    public DbSet<EmployeePropertyValue> EmployeePropertyValues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Employee → EmployeePropertyValue (One-to-Many)
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.PropertyValues)
            .WithOne(pv => pv.Employee)
            .HasForeignKey(pv => pv.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        // CustomProperty → DropdownOptions (One-to-Many)
        modelBuilder.Entity<CustomProperty>()
            .HasMany(cp => cp.DropdownOptions)
            .WithOne(opt => opt.EmployeeProperty)
            .HasForeignKey(opt => opt.CustomPropertyId)
            .OnDelete(DeleteBehavior.Cascade);

        // EmployeePropertyValue → CustomProperty (Many-to-One)
        modelBuilder.Entity<EmployeePropertyValue>()
            .HasOne(pv => pv.EmployeeProperty)
            .WithMany()
            .HasForeignKey(pv => pv.CustomPropertyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
