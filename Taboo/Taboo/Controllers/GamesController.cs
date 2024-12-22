using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taboo.DTOs.Games;
using Taboo.Exceptions;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameService _service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(GameCreateDto dto)
        {
            try
            {
                await _service.AddAsync(dto);
                return Created();
            }
            catch (Exception ex)
            {
                if (ex is IBaseException ibe)
                {
                    return StatusCode(ibe.StatusCode, new
                    {
                        StatusCode = ibe.StatusCode,
                        Message = ibe.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = ex.Message
                    });
                }
            }
        }
            [HttpPost("Start/{id}")]
            public async Task<IActionResult> Start(Guid id)
            {
                try
                {
                    await _service.StartAsync(id);
                    return Created();
                }
                catch (Exception ex)
                {
                    if (ex is IBaseException ibe)
                    {
                        return StatusCode(ibe.StatusCode, new
                        {
                            StatusCode = ibe.StatusCode,
                            Message = ibe.ErrorMessage
                        });
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = ex.Message
                        });
                    }
                }
            }
        
    } 
}
