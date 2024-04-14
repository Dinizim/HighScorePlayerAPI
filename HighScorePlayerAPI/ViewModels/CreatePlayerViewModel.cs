using System.ComponentModel.DataAnnotations;

namespace HighScorePlayerAPI.ViewModels;

public class CreatePlayerViewModel
{
    [Required]
    public string Player { get; set; }
    [Required]
    public double Score { get; set; }
}
