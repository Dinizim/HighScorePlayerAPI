namespace HighScorePlayerAPI.Models;

public class HighScore
{
    public int HighScoreId { get; set; }
    public double Score { get; set; }
 
    public int PlayerId { get; set; }
    public Player Player { get; set; }

    
    public int GameId { get; set; }
    public Game Game { get; set; }
}
