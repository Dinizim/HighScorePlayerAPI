using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HighScorePlayerAPI.Models;

public class Player
{
    [Key]
    public int Player_Id { get; set; }
    public string Username { get; set; }
    private string Login { get; set; } = null;
    private string Password { get; set; } = null;

    [JsonIgnore]
    public ICollection<HighScore> HighScores { get; set; }
}
