using Taboo.DTOs.Games;
using Taboo.DTOs.Words;
using Taboo.Entities;

namespace Taboo.Services.Abstracts
{
    public interface IGameService
    {
        Task<Guid> AddAsync(GameCreateDto dto);
        Task<WordForGameDto> StartAsync(Guid id);
        Task<Game> GetCurrentStatus(Guid id);
        Task<WordForGameDto> PassAsync(Guid id);
        Task<WordForGameDto> SuccessAsync(Guid id);
        Task<WordForGameDto> WrongAsync(Guid id);
        Task<WordForGameDto> EndAsync(Guid id);


    }
}
