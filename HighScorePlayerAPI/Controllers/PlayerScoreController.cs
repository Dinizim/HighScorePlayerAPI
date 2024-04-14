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
    public class PlayerScoreController : ControllerBase
    {
        [HttpGet("Players")]
        public async Task<IActionResult> GetPlayersAsync([FromServices] AppDbContext context)
        {
            var players = await context.Players.AsNoTracking().ToListAsync();
            return Ok(players);
        }

        [HttpGet("Players/{id}")]
        public async Task<IActionResult> GetPlayerAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var player = await context.Players.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return player == null ? NotFound() : Ok(player);
        }

        [HttpPost("Players")]
        public async Task<IActionResult> PostPlayerAsync([FromServices] AppDbContext context, [FromBody] CreatePlayerViewModel playerModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var player = new Player() { Player_Name = playerModel.Player, Score = playerModel.Score };

            try
            {
                await context.Players.AddAsync(player);
                await context.SaveChangesAsync();

                return Created($"v1/Players/{player.Id}", player);
            }
            catch (Exception e)
            {
                return BadRequest($"An error occurred while creating the player. \n ERROR: {e.Message}");
            }
        }

        [HttpDelete("Players/{id}")]
        public async Task<IActionResult> DeletePlayerAsync(
        [FromServices] AppDbContext context,
        [FromRoute] int id)
        {
            var player = await context.Players.FirstOrDefaultAsync(x => x.Id == id);
            if (player == null)
                return NotFound();
            try
            {
                context.Players.Remove(player);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"An error occurred while deleting a player entity \n ERROR: {e.Message}");
            }
        }
    }
}
