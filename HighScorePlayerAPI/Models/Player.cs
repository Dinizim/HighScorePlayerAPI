using System.ComponentModel.DataAnnotations;

namespace HighScorePlayerAPI.Models;

public class Player
{
    [Key]
    public int Player_Id { get; set; }
    public string Username { get; set; }
    private string Login { get; set; } = null;
    private string Password { get; set; } = null;
}
