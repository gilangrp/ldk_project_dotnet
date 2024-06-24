using LDKProject.Models;
using LDKProject.Models.DTO;
using LDKProject.Models.Response;

namespace LDKProject.Services;

public interface IArticleService
{
    Task<CategoryArticle> SaveCategoryArticle(CategoryArticle categoryArticle);
    Task<Article> SaveArticle(Article Article);
}

