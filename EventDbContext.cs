using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SeedData
{
  public class EventDbContext : DbContext
  {
    public DbSet<Event> Events { get; set; }
    public DbSet<Location> Locations { get; set; }
    public void AddEvents(List<Event> events)
    {
        this.Events.AddRange(events);
        this.SaveChanges();
    }
    public void AddLocations(List<Location> locations)
    {
        this.Locations.AddRange(locations);
        this.SaveChanges();
    }
    public void AddEvent(Event evt)
    {
        this.Events.Add(evt);
        this.SaveChanges();
    }
    public void AddLocation(Location loc)
    {
        this.Locations.Add(loc);
        this.SaveChanges();
    }

// dotnet add package Microsoft.Extensions.Configuration.Json
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        optionsBuilder.UseSqlServer(@config["EventDbContext:ConnectionString"]);
    }
  }
}