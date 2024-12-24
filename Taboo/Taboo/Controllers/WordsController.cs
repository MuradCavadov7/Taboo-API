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
        await _service.CreateAsync(dto);
        return Created();
    }
    [HttpDelete("id")]
    public async Task<IActionResult> Delete(int id)
    {

        await _service.DeleteAsync(id);
        return NoContent();
    }

    [HttpPut("id")]
    public async Task<IActionResult> Update(int id, WordUpdateDto dto)
    {

        await _service.UpdateAsync(id, dto);
        return Ok();
    }
}

