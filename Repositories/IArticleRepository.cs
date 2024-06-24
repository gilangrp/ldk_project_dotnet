using LDKProject.Models;

namespace LDKProject.Repositories;
public interface IArticleRepository
{
    Task<CategoryArticle> SaveCategoryArticle(CategoryArticle categoryArticle);
    Task<Article> SaveArticle(Article Article);


}
