using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.Languages;
using Taboo.Entities;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements
{
    public class LanguageServices(TabooDbContext _context, IMapper _mapper) : ILanguageServices
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            var lang = _mapper.Map<Language>(dto);
            await _context.AddAsync(lang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
           var lang = await _context.Languages.FirstOrDefaultAsync(x=>x.Code == code);
           _context.Languages.Remove(lang);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            var lang =  await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguageGetDto>>(lang);  
        }

        public async Task<Language> GetLanguageByCodeAsync(string code)
        {
            var lang = await _context.Languages.FindAsync(code);
            if (lang is null)
            {
                throw new Exception($"not found with this code({code})");
            }
           return lang;

        }

        public async Task UpdateAsync(string code, LanguageUpdateDto dto)
        {
            if (code != dto.Code)
            {
                throw new Exception("must be same");
            }
            var lang = await GetLanguageByCodeAsync(code);
            if (lang is null)
            {
                throw new Exception($"not found with this code({code})");
            }
            _mapper.Map<Language>(dto);
            lang.Code = dto.Code;
            lang.Name = dto.Name;
            lang.Icon = dto.IconUrl;
            _context.Languages.Update(lang);
            await _context.SaveChangesAsync();
        }
    }
}
