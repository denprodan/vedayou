using AutoMapper;
using VedaYOU.Models;
using VedaYOU.Persistence.DocumentTypes;

namespace VedaYOU.Infrastructure.AutoMapperProfiles
{
    public class ArticleAutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Article, ArticleViewModel>()
                .ForMember(dst => dst.Id, o => o.MapFrom(src => src.Id))
            .ForMember(dst => dst.PartOfBody, o => o.MapFrom(src => src.Body.Substring(0, 50)))
            .ForMember(dst => dst.CreateDate, o => o.MapFrom(src => src.CreateDate.ToShortDateString()))
            .ForMember(dst => dst.Icon, o => o.MapFrom(src => src.Icon))
            .ForMember(dst => dst.Title, o => o.MapFrom(src => src.Title));

            base.Configure();
        }
    }
}