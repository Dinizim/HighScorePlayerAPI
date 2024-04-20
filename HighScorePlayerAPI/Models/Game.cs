using System.ComponentModel.DataAnnotations;

namespace HighScorePlayerAPI.Models;

public class Game
{
    [Key]
    public int Game_Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    public ICollection<HighScore> HighScores { get; set; }
}
