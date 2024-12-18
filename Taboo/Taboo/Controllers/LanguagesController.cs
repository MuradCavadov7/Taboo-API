using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Taboo.DTOs.Languages;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> Post(LanguageCreateDto dto)
        {
            await _services.CreateAsync(dto);
            return Created();
        }
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            if (code == null) return NotFound();
            await _services.DeleteAsync(code);
            return NoContent();
        }
        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, LanguageUpdateDto dto)
        {
            if (code == null) return NotFound();
             await _services.UpdateAsync(code,dto);
            return NoContent();
        }
    }
}
