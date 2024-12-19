using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.Languages;
using Taboo.DTOs.Words;
using Taboo.Entities;
using Taboo.Exceptions.LanguageException;
using Taboo.Exceptions.WordException;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements
{
    public class WordService(TabooDbContext _context,IMapper _mapper) : IWordService
    {
        public async Task<int> CreateAsync(WordCreateDto dto)
        {

            if (await _context.Words.AnyAsync(x => x.LanguageCode == dto.LanguageCode && x.Text == dto.Text))
                throw new WordExistException();
            if(dto.BannedWords.Count() != 3) throw new InvalidBannedWordCountException();

            var word = _mapper.Map<Word>(dto);
            //word.BannedWords = dto.BannedWords.Select(bw => new BannedWord { Text = bw }).ToList();
            await _context.AddAsync(word);
            await _context.SaveChangesAsync();
            return word.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _getById(id);
           _context.Words.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WordGetDto>> GetAllAsync()
        {
            var word = await _context.Words.Include(x=>x.BannedWords).ToListAsync();
            return _mapper.Map<IEnumerable<WordGetDto>>(word);
        }

        public Task<Language> GetWordByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, WordUpdateDto dto)
        {
            var entity = await _getById(id);
            _mapper.Map(dto, entity);
            if (dto.BannedWords != null)
            {
                entity.BannedWords = dto.BannedWords
                    .Select(bw => new BannedWord { Text = bw })
                    .ToList();
            }
            _context.Words.Update(entity);
            await _context.SaveChangesAsync();
        }
        async Task<Word> _getById(int id)
        {
            var data = await _context.Words.FindAsync(id);
            if (data is null) throw new WordNotFoundException();
            return data;
        }
    }
}
