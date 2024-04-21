using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HighScorePlayerAPI.Models;

public class Game
{
    [Key]
    public int Game_Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    [JsonIgnore]
    public ICollection<HighScore> HighScores { get; set; }
}
