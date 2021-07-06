using AutoMapper;
using Unico.FeiraLivre.Domain.Entities;
using Unico.FeiraLivre.Infrastructure.ViewModel;

namespace Unico.FeiraLivre.Infrastructure.Mapping
{
    public class FeiraProfile : Profile
    {
        public FeiraProfile()
        {
            CreateMap<FeiraModel, Feira>()
                .ForMember(dest => dest.Id,
                        opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
