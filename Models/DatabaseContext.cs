using System;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace NewMoodApi.Models
{
  public partial class DatabaseContext : DbContext
  {

    public DbSet<Show> Shows { get; set; }
    public DbSet<EmailList> EmailLists { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Venue> Venues { get; set; }

    public DbSet<User> Users { get; set; }

    public DatabaseContext(IConfiguration configuration)
    {
      this.ConnectionString = configuration["ConnectionString"];
    }
    private string ConvertPostConnectionToConnectionString(string connection)
    {
      var _connection = connection.Replace("postgres://", String.Empty);
      var output = Regex.Split(_connection, ":|@|/");
      return $"server={output[2]};database={output[4]};User Id={output[0]}; password={output[1]}; port={output[3]}";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var envConn = Environment.GetEnvironmentVariable("DATABASE_URL");

        var conn = "server=localhost;database=NewMoodApiDatabase";
        if (envConn != null)
        {
          conn = ConvertPostConnectionToConnectionString(envConn);
        }
        optionsBuilder.UseNpgsql(conn);
      }
    }
  }
}
