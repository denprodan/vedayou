using AutoMapper;
using VedaYOU.Infrastructure.Extensions;
using VedaYOU.Models;
using VedaYOU.Persistence.DocumentTypes;

namespace VedaYOU.Infrastructure.AutoMapperProfiles
{
    public class ArticleAutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Article, ArticleInfoViewModel>()
            .ForMember(dst => dst.Id, o => o.MapFrom(src => src.Id))
            .ForMember(dst => dst.CreateDate, o => o.MapFrom(src => src.CreateDate.LocalizeDate()))
            .ForMember(dst => dst.Icon, o => o.MapFrom(src => src.Icon))
            .ForMember(dst => dst.Url, o => o.MapFrom(src => src.Url))
            .ForMember(dst => dst.Title, o => o.MapFrom(src => src.Title));

            Mapper.CreateMap<Article, ArticleViewModel>()
                .ForMember(dst => dst.Title, o => o.MapFrom(src => src.Title))
                .ForMember(dst => dst.Body, o => o.MapFrom(src => src.Body))
                .ForMember(dst => dst.HeaderImage, o => o.MapFrom(src => src.HeaderImage));

            base.Configure();
        }
    }
}