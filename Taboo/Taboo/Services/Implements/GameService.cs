using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using Taboo.DAL;
using Taboo.DTOs.Games;
using Taboo.Entities;
using Taboo.Exceptions.GameException;
using Taboo.Services.Abstracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Taboo.Services.Implements
{
    public class GameService(TabooDbContext _context, IMapper _mapper, IMemoryCache _cache) : IGameService
    {
        public async Task<Guid> AddAsync(GameCreateDto dto)
        {
            var entity = _mapper.Map<Game>(dto);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }


        public async Task StartAsync(Guid id)
        {
            var entity = await _context.Games.FindAsync(id);
            if (entity == null) throw new GameNotFoundException();
            if (entity.Score is not null)
            {
                throw new GameAlreadyFinishedException();
            }
            entity.SkipCount = 0;
            entity.SuccessAnswer = 0;
            entity.WrongAnswer = 0;
            _cache.Set(new
            {
                entity.SkipCount,
                entity.WrongAnswer,
                entity.SuccessAnswer
            },
            DateTimeOffset.Now.AddMinutes(1));
        }

    }
}
