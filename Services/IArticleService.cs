using LDKProject.Models;
using LDKProject.Models.DTO;
using LDKProject.Models.Response;

namespace LDKProject.Services;

public interface IArticleService
{
    Task<IList<CategoryArticle>> GetAllCategoryArticle();
    Task<CategoryArticle> SaveCategoryArticle(CategoryArticle categoryArticle);
    Task<IList<Article>> GetAllArticle();
    Task<Article> SaveArticle(Article Article);
    Task<IList<Author>> GetAllAuthor();
    Task<Author> SaveAuthor(Author author);

}

