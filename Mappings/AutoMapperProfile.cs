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


        }
    }
}
