using HighScorePlayerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HighScorePlayerAPI.Data;

//TODO : Apply Data Modeling
public class AppDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<HighScore> HighScores { get; set; }
    public DbSet<Game> Games { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<HighScore>()
            .HasOne(hs => hs.Player)
            .WithMany(p => p.HighScores)
            .HasForeignKey(hs => hs.PlayerId);

        modelBuilder.Entity<HighScore>()
             .HasOne(hs => hs.Game)
             .WithMany(game => game.HighScores)
             .HasForeignKey(hs => hs.GameId);

    }


}
