using LDKProject.Models;

namespace LDKProject.Repositories;
public interface IArticleRepository
{
    Task<IList<CategoryArticle>> GetAllCategoryArticle();
    Task<CategoryArticle> SaveCategoryArticle(CategoryArticle categoryArticle);
    Task<IList<Article>> GetAllArticle();
    Task<Article> SaveArticle(Article Article);
    Task<IList<Author>> GetAllAuthor();
    Task<Author> SaveAuthor(Author author);


}
