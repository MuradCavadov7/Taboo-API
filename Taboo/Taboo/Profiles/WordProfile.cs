using AutoMapper;
using Taboo.DTOs.Words;
using Taboo.Entities;

namespace Taboo.Profiles
{
    public class WordProfile : Profile
    {
        public WordProfile() 
        {
            CreateMap<WordCreateDto, Word>()
                  .ForMember(l => l.BannedWords, d => d.MapFrom(t =>
                t.BannedWords.Select(bw => new BannedWord { Text = bw }).ToList()));
            CreateMap<WordUpdateDto, Word>()
                 .ForMember(l => l.BannedWords, d => d.MapFrom(t =>
                t.BannedWords.Select(bw => new BannedWord { Text = bw }).ToList()));
            CreateMap<Word, WordGetDto>()
                 .ForMember(l => l.BannedWords, d => d.MapFrom(t =>
                t.BannedWords.Select(bw => bw.Text).ToList()));
        }

    }
}
