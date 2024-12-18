using System.Globalization;
using Taboo.DTOs.Languages;
using Taboo.Entities;

namespace Taboo.Services.Abstracts
{
    public interface ILanguageServices
    {
        Task<IEnumerable<LanguageGetDto>> GetAllAsync();
        Task CreateAsync(LanguageCreateDto dto);
        Task DeleteAsync(string code);
        Task UpdateAsync(string code, LanguageUpdateDto dto);
        Task<Language> GetLanguageByCodeAsync(string code);

    }
}
