using AutoMapper;
using LDKProject.Models;
using LDKProject.Models.DTO;
namespace LDKProject.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<CategoryArticle, CreateCategoryArticleRequest>().ReverseMap();
            CreateMap<CreateCategoryArticleRequest, CategoryArticle>().ReverseMap();
            CreateMap<CreateEventRequest, Event>().ReverseMap();
            CreateMap<CreateArticleRequest, Article>().ReverseMap();
            CreateMap<CreateAuthorRequest, Author>().ReverseMap();


        }
    }
}
