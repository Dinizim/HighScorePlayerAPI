using HighScorePlayerAPI.Data;
using HighScorePlayerAPI.ViewModels;
using HighScorePlayerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HighScorePlayerAPI.Controllers
{
    [ApiController]
    [Route("v1")]
    public class HighScoreController : ControllerBase
    {
        [HttpGet("Highscores")]
        public async Task<IActionResult> GetScoresAsync([FromServices] AppDbContext context)
        {
            var highscores = await context.HighScores.AsNoTracking().ToListAsync();
            return Ok(highscores);
        }

        [HttpGet("Highscores/{id}")]
        public async Task<IActionResult> GetScoreAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var highscore = await context.HighScores.AsNoTracking().FirstOrDefaultAsync(x => x.HighScoreId == id);
            return highscore == null ? NotFound() : Ok(highscore);
        }

        [HttpPost("Highscores")]
        public async Task<IActionResult> PostHighScoreAsync(
            [FromServices] AppDbContext _context,
            [FromBody] CreateScoreViewModel model_score)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var player = await GetOrCreatePlayerAsync(_context, model_score.Player);
                var game = await GetOrCreateGameAsync(_context, model_score.Game);

                var highscore = new HighScore
                {
                    PlayerId = player.Player_Id,
                    GameId = game.Game_Id,
                    Score = model_score.Score
                };

                _context.HighScores.Add(highscore);
                await _context.SaveChangesAsync();

                return Created($"v1/HighScores/{highscore.HighScoreId}", highscore);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        private async Task<Player> GetOrCreatePlayerAsync(AppDbContext _context, string playerName)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.Username == playerName);
            if (player == null)
            {
                player = new Player { Username = playerName };
                _context.Players.Add(player);
                await _context.SaveChangesAsync();
            }
            return player;
        }

        private async Task<Game> GetOrCreateGameAsync(AppDbContext _context, string gameName)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Name == gameName);
            if (game == null)
            {
                game = new Game { Name = gameName, Type = "Default" };
                _context.Games.Add(game);
                await _context.SaveChangesAsync();
            }
            return game;
        }
    }
}
