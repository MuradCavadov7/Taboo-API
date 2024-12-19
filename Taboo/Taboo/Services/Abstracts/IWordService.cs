using Taboo.DTOs.Languages;
using Taboo.DTOs.Words;
using Taboo.Entities;

namespace Taboo.Services.Abstracts
{
    public interface IWordService
    {
        Task<IEnumerable<WordGetDto>> GetAllAsync();
        Task<int> CreateAsync(WordCreateDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, WordUpdateDto dto);
        Task<Language> GetWordByIdAsync(int id);
    }
}
