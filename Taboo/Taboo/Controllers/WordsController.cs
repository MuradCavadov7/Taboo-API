using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taboo.DTOs.Languages;
using Taboo.DTOs.Words;
using Taboo.Exceptions;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WordsController(IWordService _service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var words = await _service.GetAllAsync();
        return Ok(words);
    }
    [HttpPost]
    public async Task<IActionResult> Post(WordCreateDto dto)
    {
        try
        {
            await _service.CreateAsync(dto);
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
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();
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
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = ex.Message
                });
            }
        }

    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, WordUpdateDto dto)
    {
        try
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
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
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = ex.Message
                });
            }
        }

    }
}
