using AutoMapper;
using Taboo.DTOs.Games;
using Taboo.Entities;

namespace Taboo.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile() 
        {
            CreateMap<GameCreateDto, Game>()
                .ForMember(l => l.BannedWordCount, d => d.MapFrom(t => t.GameLevel))
                .ForMember(l =>l.Time,d=>d.MapFrom(t=>new TimeSpan(t.Seconds* 10000000)));
        }
    }
}
