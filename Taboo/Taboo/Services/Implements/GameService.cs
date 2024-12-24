using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using Taboo.DAL;
using Taboo.DTOs.Games;
using Taboo.DTOs.Words;
using Taboo.Entities;
using Taboo.Exceptions.GameException;
using Taboo.ExternalServices.Abstracts;
using Taboo.Services.Abstracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Taboo.Services.Implements
{
    public class GameService(TabooDbContext _context, IMapper _mapper,ICacheService _cache) : IGameService
    {
        public async Task<Guid> AddAsync(GameCreateDto dto)
        {
            var entity = _mapper.Map<Game>(dto);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<WordForGameDto> EndAsync(Guid id)
        {
            var status = await _getGameStatusAsync(id);
            await _addNewWords(status);
            var entity = await _context.Games.FindAsync(id);
            if (entity == null) throw new GameNotFoundException();
            entity.Score = status.Success;
            await _cache.RemoveAsync<GameStatusDto>(id.ToString());
            return null;

        }

        public async Task<Game> GetCurrentStatus(Guid id)
        {
            var entity = await _context.Games.FindAsync(id);
            if (entity == null) throw new GameNotFoundException();
            return entity;
        }

        public async Task<WordForGameDto> PassAsync(Guid id)
        {
            var status = await _getGameStatusAsync(id);
            await _addNewWords(status);
            if (status.MaxPass > status.Pass)
            {
                status.Pass++;
                var word = status.Words.Pop();
                await _cache.SetAsync(id.ToString(), status, 1);
                return word;
            }
            return null;
        }

        public async Task<WordForGameDto> StartAsync(Guid id)
        {
            var entity = await _context.Games.FindAsync(id);
            if (entity == null) throw new GameNotFoundException();
            if (entity.Score is not null)
            {
                throw new GameAlreadyFinishedException();
            }
            var words = await _context.Words.Where(x => x.LanguageCode == entity.LanguageCode).Take(10)
                .Select(x => new WordForGameDto
                {
                    Id = x.Id,
                    Name = x.Text,
                    BannedWords = x.BannedWords.Select(x =>x.Text).ToList()
                }).ToListAsync();
            GameStatusDto status = new GameStatusDto
            {
                Wrong = 0,
                Pass = 0,
                Success = 0,
                Words = new Stack<WordForGameDto>(words),
                MaxPass = (byte)entity.SkipCount,
                LanguageCode = entity.LanguageCode,
                UseWordId = words.Select(x => x.Id).ToList()
            };
            var word = status.Words.Pop();
            await _cache.SetAsync(id.ToString(), status, 1);
            return word;
        }

        public async Task<WordForGameDto> SuccessAsync(Guid id)
        {
            var status = await _getGameStatusAsync(id);
            await _addNewWords(status);
            status.Success++;
            var word = status.Words.Pop();
            await _cache.SetAsync(id.ToString(), status, 1);
            return word;
        }

        public async Task<WordForGameDto> WrongAsync(Guid id)
        {
            var status = await _getGameStatusAsync(id);
            await _addNewWords(status);
            status.Wrong++;
            var word = status.Words.Pop();
            await _cache.SetAsync(id.ToString(), status, 1);
            return word;
        }
        private async Task<GameStatusDto> _getGameStatusAsync(Guid id)
        {
            GameStatusDto status = await _cache.GetAsync<GameStatusDto>(id.ToString());
            if (status is null) throw new  GameNotFoundException();
            return (status);
        } 
        private async Task _addNewWords(GameStatusDto dto)
        {
            if(dto.Words.Count < 6)
            {
                var newWords = await _context.Words.Where(x => x.LanguageCode == dto.LanguageCode &&
                !dto.UseWordId.Contains(x.Id)).Take(5)
                .Select(x=>new WordForGameDto
                {
                    Id = x.Id,
                    BannedWords = x.BannedWords.Select(y=>y.Text).ToList(),
                    Name = x.Text
                }).ToListAsync();
                dto.UseWordId.AddRange(newWords.Select(x => x.Id));
                newWords.ForEach(x => dto.Words.Push(x));
            }
        }
    }
}
