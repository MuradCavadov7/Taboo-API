using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.Languages;
using Taboo.Entities;
using Taboo.Exceptions.LanguageException;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements
{
    public class LanguageServices(TabooDbContext _context, IMapper _mapper) : ILanguageServices
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code)) throw new LanguageExistException();
            var lang = _mapper.Map<Language>(dto);
            await _context.AddAsync(lang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
           var lang = await _getById(code);

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
            var lang = await _getById(code);
            return _mapper.Map<Language>(lang);
        }

        public async Task UpdateAsync(string code, LanguageUpdateDto dto)
        {
            var lang = await _getById(code);
           _mapper.Map(dto, lang);
            _context.Languages.Update(lang);
            await _context.SaveChangesAsync();
        }
        async Task<Language> _getById(string code)
        {
           var data =await _context.Languages.FindAsync(code);
            if ( data is null) throw new LanguageNotFoundException();
            return data;
        }
        
    }
}
