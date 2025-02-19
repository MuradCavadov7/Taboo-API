﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taboo.DTOs.Games;
using Taboo.Exceptions;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController(IGameService _service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(GameCreateDto dto)
    {
        return Ok(await _service.AddAsync(dto));

    }
    [HttpPost("[action]/{id}")]
    public async Task<IActionResult> Start(Guid id)
    {
        return Ok(await _service.StartAsync(id));
    }
    [HttpPost("[action]/{id}")]
    public async Task<IActionResult> Success(Guid id)
    {
        return Ok(await _service.SuccessAsync(id));
    }
    [HttpGet]
    public async Task<IActionResult> GetGameData(Guid id)
    {
        return Ok(await _service.GetCurrentStatus(id));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> EndGame(Guid id)
    {
        return Ok(await _service.EndAsync(id));
    }

}
