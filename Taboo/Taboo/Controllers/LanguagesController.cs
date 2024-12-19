using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Taboo.DTOs.Languages;
using Taboo.Exceptions;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController(ILanguageServices _services) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {

        var languages = await _services.GetAllAsync();
        return Ok(languages);
    }

    [HttpPut]
    public async Task<IActionResult> GetId(string code)
    {
        try
        {
           var data = await _services.GetLanguageByCodeAsync(code);
            return Ok(data);
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
    [HttpPost]
    public async Task<IActionResult> Post(LanguageCreateDto dto)
    {
        try
        {
            await _services.CreateAsync(dto);
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
    [HttpDelete("{code}")]
    public async Task<IActionResult> Delete(string code)
    {
        try
        {
            await _services.DeleteAsync(code);
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
    [HttpPut("{code}")]
    public async Task<IActionResult> Update(string code, LanguageUpdateDto dto)
    {
        try
        {
            await _services.UpdateAsync(code, dto);
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