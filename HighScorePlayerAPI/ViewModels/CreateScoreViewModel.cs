using System.ComponentModel.DataAnnotations;

namespace HighScorePlayerAPI.ViewModels;

public class CreateScoreViewModel
{
    [Required]
    public string Player { get; set; }
    [Required]
    public string Game { get; set; }
    [Required]
    public double Score { get; set; }
}
