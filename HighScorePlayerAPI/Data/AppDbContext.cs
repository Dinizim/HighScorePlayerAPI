using HighScorePlayerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HighScorePlayerAPI.Data;

//TODO : Apply Data Modeling
public class AppDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }



}
